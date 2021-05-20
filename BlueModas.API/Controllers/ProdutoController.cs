using BlueModas.API.Domain.Entidades;
using BlueModas.API.Domain.Interface;
using BlueModas.API.Domain.Retorno;
using BlueModas.API.Exceptions;
using BlueModas.API.Exceptions.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        /// <summary>
        /// Obtem a lista de todos os usuários do sistema.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetAll()
        {
            return await this.produtoRepository.GetAll();
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado.")]
        public async Task<ActionResult<Produto>> GetById(Guid id)
        {
            var retorno = await this.produtoRepository.GetById(id);

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
        public async Task<IActionResult> Update(Guid id, Produto produto)
        {
            var retorno = this.produtoRepository.Update(id, produto);

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
        [SwaggerOperation(Summary = "Cria um produto novo.",
                          Description = "Cria um novo produto para realizar vendas.",
                          OperationId = "CreateProduct")]
        [SwaggerResponse(StatusCodes.Status201Created, "Usuário criado.", typeof(Produto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro na criação do produto.", typeof(FieldValidate))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.", typeof(GeneralError))]
        public async Task<ActionResult<Produto>> Add(Produto produto)
        {
            var retorno = await this.produtoRepository.Add(produto);
            return CreatedAtAction("GetAll", new { id = retorno.Id }, retorno);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta poduto.",
                          Description = "Delete um poduto baseado no id.",
                          OperationId = "DeleteProduct")]
        [SwaggerResponse(StatusCodes.Status201Created, "Produto excluido.", typeof(Produto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro na exclusão do produto.", typeof(FieldValidate))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.", typeof(GeneralError))]
        public async Task<ActionResult<Produto>> Delete(Guid id)
        {
            var retorno = await this.produtoRepository.Delete(id);

            if (retorno == null)
            {
                return NotFound();
            }

            return retorno;
        }
    }
}
