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
        private readonly BlueModasDbContext applicationDbContext; 
        #endregion

        #region [ Constructor ]
        public ClienteRepository(BlueModasDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        } 
        #endregion

        #region [ Public Functions ]
        public async Task<Cliente> Add(Cliente cliente)
        {
            await this.applicationDbContext.Cliente.AddAsync(cliente);
            await this.applicationDbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente> Delete(Guid id)
        {
            var cliente = await this.applicationDbContext.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return null;
            }

            this.applicationDbContext.Cliente.Remove(cliente);
            await this.applicationDbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            return await this.applicationDbContext.Cliente.ToListAsync();
        }

        public async Task<Cliente> GetById(Guid id)
        {
            var cliente = await this.applicationDbContext.Cliente.FindAsync(id);

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

            this.applicationDbContext.Entry(cliente).State = EntityState.Modified;

            try
            {
                this.applicationDbContext.SaveChangesAsync();
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
            return this.applicationDbContext.Cliente.Any(e => e.Id == id);
        }
        #endregion
    }
}
