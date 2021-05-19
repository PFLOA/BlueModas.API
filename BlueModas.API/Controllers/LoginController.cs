using BlueModas.API.Domain.Entidades;
using BlueModas.API.Domain.Interface;
using BlueModas.API.Exceptions;
using BlueModas.API.Exceptions.Login;
using BlueModas.API.Filters.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        [HttpPost]
        [SwaggerOperation(Description = "Realiza login no sistema",
                          OperationId = "LoginUser",
                          Summary = "login no sistema.")]
        [LoginModelStateErrorFilter]
        [SwaggerResponse(StatusCodes.Status201Created, "Login realizado.", typeof(ResponseLogin))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro no login do usuário.", typeof(LoginError))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado.", typeof(LoginError))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.", typeof(GeneralError))]
        public async Task<ActionResult<Users>> LoginUser([FromBody] Login login)
        {
            if (login == null)
            {
                return BadRequest(new
                {
                    Errors = new[] { "Parâmetros incorretos, verifique o corpo da requisição." }
                });
            }

            var result = await this.loginRepository.LoginUser(login);

            if (result == null)
            {
                return NotFound(new
                {
                    Errors = new[] { "Usuário ou senha incorretos." }
                });
            }

            var secret = Encoding.ASCII.GetBytes("12b6fb24-adb8-4ce5-aa49-95a4sads4ad561sa");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()),
                    new Claim(ClaimTypes.Name, result.UserName),
                    new Claim(ClaimTypes.Email, result.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            var generatedToken = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return Ok(new
            {
                Token = generatedToken,
                User = result
            });
        }
    }
}
