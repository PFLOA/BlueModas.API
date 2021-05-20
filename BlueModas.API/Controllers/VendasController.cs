using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BlueModas.API.Domain.Interface;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Http;
using BlueModas.API.Domain.Entidades;
using BlueModas.API.Exceptions.Users;
using BlueModas.API.Exceptions;
using System.Threading.Tasks;
using System.Collections.Generic;
using BlueModas.API.Filters.Vendas;

namespace BlueModas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class VendasController : Controller
    {
        private readonly IVendasRepository vendasRepository;

        public VendasController(IVendasRepository vendasRepository)
        {
            this.vendasRepository = vendasRepository;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria uma venda.",
                          Description = "Criação de nova venda.",
                          OperationId = "CriateVenda")]
        
        [SwaggerResponse(StatusCodes.Status201Created, "Venda criada.", typeof(Venda))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro na criação da venda.", typeof(FieldValidate))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.", typeof(GeneralError))]
        public async Task<ActionResult<Venda>> Add([FromBody]Venda venda)
        {
            var retorno = await this.vendasRepository.Add(venda);
            return CreatedAtAction("GetAll", new { id = retorno.Id }, retorno);
        }

        /// <summary>
        /// Obtem a lista de todas as vendas do sistema.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        public async Task<ActionResult<IEnumerable<Venda>>> GetAll()
        {
            return await this.vendasRepository.GetAll();
        }
    }
}
