using BlueModas.API.Domain.Entidades;
using BlueModas.API.Domain.Interface;
using BlueModas.API.Infra.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.API.Infra.Repository
{
    public class VendasRepository : IVendasRepository
    {
        private readonly BlueModasDbContext applicationDbContext;

        public VendasRepository(BlueModasDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<Venda> Add(Venda venda)
        {
            await this.applicationDbContext.Venda.AddAsync(venda);
            await this.applicationDbContext.SaveChangesAsync();

            return venda;
        }
    }
}
