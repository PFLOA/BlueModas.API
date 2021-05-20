using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlueModas.API.Domain.Entidades;
using BlueModas.API.Filters.Users;
using BlueModas.API.Exceptions.Users;
using BlueModas.API.Exceptions;
using System;
using BlueModas.API.Domain.Interface;
using BlueModas.API.Domain.Retorno;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BlueModas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        /// <summary>
        /// Obtem a lista de todos os usuários do sistema.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        public async Task<ActionResult<IEnumerable<Users>>> GetAll()
        {
            return await this.usersRepository.GetAll();
        }

        [HttpGet("{id}")]
        [UserModelStateValidateFilter]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado.")]
        public async Task<ActionResult<Users>> GetById(Guid id)
        {
            var retorno = await this.usersRepository.GetById(id);

            if (retorno == null)
            {
                return NotFound();
            }

            return retorno;
        }

        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Verifique os parâmetros passados.")]
        public async Task<IActionResult> Update(Guid id, [FromBody]Users users)
        {
            var retorno = this.usersRepository.Update(id, users);

            if (ReturnLogics.UserDifferentIdEnum(retorno))
            {
                return BadRequest();
            }

            if (ReturnLogics.UserNotFoundEnum(retorno))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um usuário novo.",
                          Description = "Cria um novo usuário para realizar login no banco de dados.",
                          OperationId = "CreateUser")]
        [UserModelStateValidateFilter]
        [SwaggerResponse(StatusCodes.Status201Created, "Usuário criado.", typeof(Users))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro na criação do usuário.", typeof(FieldValidate))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.", typeof(GeneralError))]
        public async Task<ActionResult<Users>> Add(Users users)
        {
            var retorno = await this.usersRepository.Add(users);
            return CreatedAtAction("GetAll", new { id = retorno.Id }, retorno);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta usuário.",
                          Description = "Delete um usuario baseado no id.",
                          OperationId = "DeleteUser")]
        [SwaggerResponse(StatusCodes.Status201Created, "Usuário excluido.", typeof(Users))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro na exclusão do usuário.", typeof(FieldValidate))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.", typeof(GeneralError))]
        public async Task<ActionResult<Users>> Delete(Guid id)
        {
            var retorno = await this.usersRepository.Delete(id);

            if (retorno == null)
            {
                return NotFound();
            }

            return retorno;
        }
    }
}
