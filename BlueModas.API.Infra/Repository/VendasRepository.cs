using BlueModas.API.Domain.Entidades;
using BlueModas.API.Domain.Interface;
using BlueModas.API.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.API.Infra.Repository
{
    public class VendasRepository : IVendasRepository
    {
        private readonly BlueModasDbContext blueModasDbContext;

        public VendasRepository(BlueModasDbContext blueModasDbContext)
        {
            this.blueModasDbContext = blueModasDbContext;
        }

        public async Task<Venda> Add(Venda venda)
        {
            await this.blueModasDbContext.Venda.AddAsync(venda);
            await this.blueModasDbContext.SaveChangesAsync();

            return venda;
        }

        public async Task<ActionResult<IEnumerable<Venda>>> GetAll()
        {
            return await this.blueModasDbContext.Venda
                       .Include(p => p.Cliente)
                        .ThenInclude(b => b.Enderecos)
                       .Include(p => p.Itens)
                        .ThenInclude(b => b.Produto)
                         .ThenInclude(c=>c.Categoria)
                       .Include(p => p.Cliente)
                        .ThenInclude(b => b.Telefones)
                       .ToListAsync();
        }
    }
}
