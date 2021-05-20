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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly BlueModasDbContext applicationDbContext;

        public ProdutoRepository(BlueModasDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        #region [ Public Functions ]
        public async Task<Produto> Add(Produto produto)
        {
            await this.applicationDbContext.Produto.AddAsync(produto);
            await this.applicationDbContext.SaveChangesAsync();

            return produto;
        }
        public async Task<Produto> Delete(Guid id)
        {
            var produto = await this.applicationDbContext.Produto.FindAsync(id);

            if (produto == null)
            {
                return null;
            }

            this.applicationDbContext.Produto.Remove(produto);
            await this.applicationDbContext.SaveChangesAsync();

            return produto;
        }
        public async Task<ActionResult<IEnumerable<Produto>>> GetAll()
        {
            return await this.applicationDbContext.Produto.ToListAsync();
        }
        public async Task<Produto> GetById(Guid id)
        {
            var produto = await this.applicationDbContext.Produto.FindAsync(id);

            if (produto == null)
            {
                return null;
            }

            return produto;
        }
        public RetornosEnum Update(Guid id, Produto produto)
        {
            if (id != produto.Id)
            {
                return RetornosEnum.UserDifferentId;
            }

            this.applicationDbContext.Entry(produto).State = EntityState.Modified;

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
            return this.applicationDbContext.Users.Any(e => e.Id == id);
        }
        #endregion
    }
}
