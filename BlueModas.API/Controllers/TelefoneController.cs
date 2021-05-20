using BlueModas.API.Domain.Entidades;
using BlueModas.API.Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneRepository telefoneRepository;

        public TelefoneController(ITelefoneRepository telefoneRepository)
        {
            this.telefoneRepository = telefoneRepository;
        }
        /// <summary>
        /// Obtem a lista de todos os usuários do sistema.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Não Autorizado.")]
        public async Task<ActionResult<IEnumerable<Telefone>>> GetAll()
        {
            return await this.telefoneRepository.GetAll();
        }
    }
}
