using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueModas.API.Domain.Interface;
using Swashbuckle.AspNetCore.Annotations;
using BlueModas.API.Domain.Entidades;
using BlueModas.API.Exceptions.Users;
using BlueModas.API.Exceptions;
using BlueModas.API.Domain.Retorno;

namespace BlueModas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        /// <summary>
        /// Obtem a lista de todos os usuários do sistema.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        public async Task<ActionResult<IEnumerable<Categorias>>> GetAll()
        {
            return await this.categoriaRepository.GetAll();
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado.")]
        public async Task<ActionResult<Categorias>> GetById(int id)
        {
            var retorno = await this.categoriaRepository.GetById(id);

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
        public async Task<IActionResult> Update(int id, Categorias categorias)
        {
            var retorno = this.categoriaRepository.Update(id, categorias);

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
        [SwaggerResponse(StatusCodes.Status201Created, "Usuário criado.", typeof(Categorias))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro na criação do usuário.", typeof(FieldValidate))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.", typeof(GeneralError))]
        public async Task<ActionResult<Categorias>> Add(Categorias categorias)
        {
            var retorno = await this.categoriaRepository.Add(categorias);
            return CreatedAtAction("GetAll", new { id = retorno.Id }, retorno);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta usuário.",
                          Description = "Delete um usuario baseado no id.",
                          OperationId = "DeleteUser")]
        [SwaggerResponse(StatusCodes.Status201Created, "Usuário excluido.", typeof(Categorias))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro na exclusão do usuário.", typeof(FieldValidate))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.", typeof(GeneralError))]
        public async Task<ActionResult<Categorias>> Delete(int id)
        {
            var retorno = await this.categoriaRepository.Delete(id);

            if (retorno == null)
            {
                return NotFound();
            }

            return retorno;
        }
    }
}
