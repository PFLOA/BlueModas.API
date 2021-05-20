using BlueModas.API.Domain.Entidades;
using BlueModas.API.Domain.Enum;
using BlueModas.API.Domain.Interface;
using BlueModas.API.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.API.Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        #region [ Attribute ]
        private readonly BlueModasDbContext blueModasDbContext;
        #endregion

        #region [ Constructor ]
        public ClienteRepository(BlueModasDbContext blueModasDbContext)
        {
            this.blueModasDbContext = blueModasDbContext;
        }
        #endregion

        #region [ Public Functions ]
        public async Task<Cliente> Add(Cliente cliente)
        {
            await this.blueModasDbContext.Cliente.AddAsync(cliente);
            await this.blueModasDbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente> Delete(Guid id)
        {
            var cliente = await this.blueModasDbContext.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return null;
            }

            this.blueModasDbContext.Cliente.Remove(cliente);
            await this.blueModasDbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            return await this.blueModasDbContext.Cliente
                .Include(p => p.Enderecos)
                .Include(p => p.Telefones)
                .ToListAsync();
        }

        public async Task<Cliente> GetById(Guid id)
        {
            var cliente = await this.blueModasDbContext.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return null;
            }

            return cliente;
        }

        public RetornosEnum Update(Guid id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return RetornosEnum.UserDifferentId;
            }

            this.blueModasDbContext.Entry(cliente).State = EntityState.Modified;

            try
            {
                this.blueModasDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return RetornosEnum.UserNotFound;
                }
                else
                {
                    throw;
                }
            }

            return RetornosEnum.UserUpdated;
        }
        #endregion

        #region [ Private Functions ]
        private bool UsersExists(Guid id)
        {
            return this.blueModasDbContext.Cliente.Any(e => e.Id == id);
        }
        #endregion
    }
}
