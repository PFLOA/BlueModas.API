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
    public class CategoriaRepository : ICategoriaRepository
    {
        #region [ Attributes ]
        private readonly BlueModasDbContext blueModasDbContext;
        #endregion

        #region [ Constructors ]
        public CategoriaRepository(BlueModasDbContext blueModasDbContext)
        {
            this.blueModasDbContext = blueModasDbContext;
        }
        #endregion

        #region [ Public Functions ]
        public async Task<Categorias> Add(Categorias Categorias)
        {
            await this.blueModasDbContext.Categorias.AddAsync(Categorias);
            await this.blueModasDbContext.SaveChangesAsync();

            return Categorias;
        }
        public async Task<Categorias> Delete(int id)
        {
            var categoria = await this.blueModasDbContext.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return null;
            }

            this.blueModasDbContext.Categorias.Remove(categoria);
            await this.blueModasDbContext.SaveChangesAsync();

            return categoria;
        }
        public async Task<ActionResult<IEnumerable<Categorias>>> GetAll()
        {
            return await this.blueModasDbContext.Categorias.ToListAsync();
        }
        public async Task<Categorias> GetById(int id)
        {
            var categoria = await this.blueModasDbContext.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return null;
            }

            return categoria;
        }
        public RetornosEnum Update(int id, Categorias categorias)
        {
            if (id != categorias.Id)
            {
                return RetornosEnum.UserDifferentId;
            }

            this.blueModasDbContext.Entry(categorias).State = EntityState.Modified;

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
            return this.blueModasDbContext.Categorias.Any(e => e.Id == id);
        }
        #endregion
    }
}
