using BlueModas.API.Domain;
using BlueModas.API.Domain.Entidades;
using BlueModas.API.Domain.Enum;
using BlueModas.API.Domain.Interface;
using BlueModas.API.Domain.Retorno;
using BlueModas.API.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.API.Infra.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly BlueModasDbContext blueModasDbContext;

        public LoginRepository(BlueModasDbContext blueModasDbContext)
        {
            this.blueModasDbContext = blueModasDbContext;
        }

        public async Task<Cliente> LoginCliente(Login login)
        {
            if (login == null)
            {
                return null;
            }

            var retorno = this.blueModasDbContext.Cliente.ToList().First(e => e.UserName == login.UserName.ToUpper() && e.Password == login.Password);

            if (retorno == null)
            {
                return null;
            }

            return retorno;
        }
        public async Task<Users> LoginUser(Login login)
        {
            if (login == null)
            {
                return null;
            }

            var list = this.blueModasDbContext.Users.ToList();

            if (list.Count > 0)
            {
                var retorno = list.First(e => e.UserName == login.UserName && e.Password == login.Password);
                return retorno;
            }

            return null;
        }
    }
}
