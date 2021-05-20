using BlueModas.API.Domain.Entidades;
using BlueModas.API.Domain.Interface;
using BlueModas.API.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueModas.API.Infra.Repository
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly BlueModasDbContext blueModasDbContext;

        public TelefoneRepository(BlueModasDbContext blueModasDbContext)
        {
            this.blueModasDbContext = blueModasDbContext;
        }

        public async Task<ActionResult<IEnumerable<Telefone>>> GetAll()
        {
            return await this.blueModasDbContext.Telefone.ToListAsync();
        }
    }
}
