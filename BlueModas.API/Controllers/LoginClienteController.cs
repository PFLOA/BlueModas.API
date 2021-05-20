using BlueModas.API.Domain.Entidades;
using BlueModas.API.Domain.Interface;
using BlueModas.API.Domain.JWT;
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
    public class LoginClienteController : ControllerBase
    {
        private readonly ILoginRepository loginRepository;

        public LoginClienteController(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        [HttpPost]
        [SwaggerOperation(Description = "Realiza login no sistema como cliente",
                          OperationId = "LoginCliente",
                          Summary = "login no sistema.")]
        [LoginModelStateErrorFilter]
        [SwaggerResponse(StatusCodes.Status201Created, "Login realizado.", typeof(ResponseLogin))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro no login do cliente.", typeof(LoginError))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado.", typeof(LoginError))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.", typeof(GeneralError))]
        public async Task<ActionResult<Cliente>> LoginCliente([FromBody] Login login)
        {
            if (login == null)
            {
                return BadRequest(new
                {
                    Errors = new[] { "Parâmetros incorretos, verifique o corpo da requisição." }
                });
            }

            var result = await this.loginRepository.LoginCliente(login);

            if (result == null)
            {
                return NotFound(new
                {
                    Errors = new[] { "Usuário ou senha incorretos." }
                });
            }

            var generatedToken = RetornoJwt.RetornoJwtString(result);

            return Ok(new
            {
                Token = generatedToken,
                User = result
            });
        }
    }
}
