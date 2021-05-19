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
        private readonly ApplicationDbContext applicationDbContext;
        #endregion

        #region [ Constructors ]
        public UsersRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        #endregion

        #region [ Public Functions ]
        public async Task<Users> Add(Users users)
        {
            await this.applicationDbContext.Users.AddAsync(users);
            await this.applicationDbContext.SaveChangesAsync();

            return users;
        }
        public async Task<Users> Delete(Guid id)
        {
            var users = await this.applicationDbContext.Users.FindAsync(id);

            if (users == null)
            {
                return null;
            }

            this.applicationDbContext.Users.Remove(users);
            await this.applicationDbContext.SaveChangesAsync();

            return users;
        }
        public async Task<ActionResult<IEnumerable<Users>>> GetAll()
        {
            return await this.applicationDbContext.Users.ToListAsync();
        }
        public async Task<Users> GetById(Guid id)
        {
            var users = await this.applicationDbContext.Users.FindAsync(id);

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

            this.applicationDbContext.Entry(users).State = EntityState.Modified;

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
