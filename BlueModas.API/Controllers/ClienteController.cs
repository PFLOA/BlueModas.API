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
using Microsoft.AspNetCore.Cors;

namespace BlueModas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        /// <summary>
        /// Obtem a lista de todos os usuários do sistema.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            return await this.clienteRepository.GetAll();
        }

        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Cliente não encontrado.")]
        public async Task<ActionResult<Cliente>> GetById(Guid id)
        {
            var retorno = await this.clienteRepository.GetById(id);

            if (retorno == null)
            {
                return NotFound();
            }

            return retorno;
        }

        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Cliente não encontrado.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Verifique os parâmetros passados.")]
        public async Task<IActionResult> Update(Guid id, [FromBody]Cliente cliente)
        {
            var retorno = this.clienteRepository.Update(id, cliente);

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
        [SwaggerOperation(Summary = "Cria um cliente novo.",
                          Description = "Cria um novo cliente para realizar login no banco de dados.",
                          OperationId = "CreateCliente")]
        [SwaggerResponse(StatusCodes.Status201Created, "Cliente criado.", typeof(Cliente))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro na criação do cliente.", typeof(FieldValidate))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.", typeof(GeneralError))]
        public async Task<ActionResult<Cliente>> Add([FromBody]Cliente cliente)
        {
            try
            {
                var retorno = await this.clienteRepository.Add(cliente);
                return CreatedAtAction("GetAll", new { id = retorno.Id }, retorno);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta cliente.",
                          Description = "Delete um usuario baseado no id.",
                          OperationId = "DeleteCliente")]
        [SwaggerResponse(StatusCodes.Status201Created, "Cliente excluido.", typeof(Cliente))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro na exclusão do cliente.", typeof(FieldValidate))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Cliente não encontrado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.", typeof(GeneralError))]
        public async Task<ActionResult<Cliente>> Delete(Guid id)
        {
            var retorno = await this.clienteRepository.Delete(id);

            if (retorno == null)
            {
                return NotFound();
            }

            return retorno;
        }
    }
}
