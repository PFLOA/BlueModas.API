using BlueModas.API.Domain;
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
    public class UsersRepository : IUsersRepository
    {
        #region [ Attributes ]
        private readonly BlueModasDbContext blueModasDbContext;
        #endregion

        #region [ Constructors ]
        public UsersRepository(BlueModasDbContext blueModasDbContext)
        {
            this.blueModasDbContext = blueModasDbContext;
        }
        #endregion

        #region [ Public Functions ]
        public async Task<Users> Add(Users users)
        {
            await this.blueModasDbContext.Users.AddAsync(users);
            await this.blueModasDbContext.SaveChangesAsync();

            return users;
        }
        public async Task<Users> Delete(Guid id)
        {
            var users = await this.blueModasDbContext.Users.FindAsync(id);

            if (users == null)
            {
                return null;
            }

            this.blueModasDbContext.Users.Remove(users);
            await this.blueModasDbContext.SaveChangesAsync();

            return users;
        }
        public async Task<ActionResult<IEnumerable<Users>>> GetAll()
        {
            return await this.blueModasDbContext.Users.ToListAsync();
        }
        public async Task<Users> GetById(Guid id)
        {
            var users = await this.blueModasDbContext.Users.FindAsync(id);

            if (users == null)
            {
                return null;
            }

            return users;
        }
        public RetornosEnum Update(Guid id, Users users)
        {
            if (id != users.Id)
            {
                return RetornosEnum.UserDifferentId;
            }

            this.blueModasDbContext.Entry(users).State = EntityState.Modified;

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
            return this.blueModasDbContext.Users.Any(e => e.Id == id);
        }
        #endregion
    }
}
