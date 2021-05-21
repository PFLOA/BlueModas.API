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
        private readonly BlueModasDbContext blueModasDbContext;

        public ProdutoRepository(BlueModasDbContext blueModasDbContext)
        {
            this.blueModasDbContext = blueModasDbContext;
        }

        #region [ Public Functions ]
        public async Task<Produto> Add([FromBody]Produto produto)
        {
            await this.blueModasDbContext.Produto.AddAsync(produto);
            await this.blueModasDbContext.SaveChangesAsync();

            return produto;
        }
        public async Task<Produto> Delete(int id)
        {
            var produto = await this.blueModasDbContext.Produto.FindAsync(id);

            if (produto == null)
            {
                return null;
            }

            this.blueModasDbContext.Produto.Remove(produto);
            await this.blueModasDbContext.SaveChangesAsync();

            return produto;
        }
        public async Task<ActionResult<IEnumerable<Produto>>> GetAll()
        {
            return await this.blueModasDbContext.Produto
                    .ToListAsync();
        }
        public async Task<Produto> GetById(int id)
        {
            var produto = await this.blueModasDbContext.Produto.FindAsync(id);

            if (produto == null)
            {
                return null;
            }

            return produto;
        }
        public RetornosEnum Update(int id, [FromBody]Produto produto)
        {
            if (id != produto.Id)
            {
                return RetornosEnum.UserDifferentId;
            }

            this.blueModasDbContext.Entry(produto).State = EntityState.Modified;

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
        private bool UsersExists(int id)
        {
            return this.blueModasDbContext.Produto.Any(e => e.Id == id);
        }
        #endregion
    }
}
