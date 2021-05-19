using BlueModas.API.Domain.Entidades;
using BlueModas.API.Infra.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.API.Infra.Mock
{
    public class UsersMockData
    {
        public static void Add(ApplicationDbContext appicationDbContext)
        {
            appicationDbContext.Users.AddRange(UsersListMock());
            appicationDbContext.SaveChanges();
        }

        private static List<Users> UsersListMock()
        {
            var listUsers = new List<Users>();

            listUsers.Add(new Users
            {
                Id = Guid.NewGuid(),
                Email = "user1@email.com",
                Name = "Paulo",
                Password = "123",
                UserName = "paulo"
            });

            listUsers.Add(new Users
            {
                Id = Guid.NewGuid(),
                Email = "user2@email.com",
                Name = "Pedro",
                Password = "Mudar@123Senha",
                UserName = "pedro"
            });

            listUsers.Add(new Users
            {
                Id = Guid.NewGuid(),
                Email = "user3@email.com",
                Name = "Potira",
                Password = "Mudar@123Senha",
                UserName = "potira"
            });

            listUsers.Add(new Users
            {
                Id = Guid.NewGuid(),
                Email = "user4@email.com",
                Name = "Francisca",
                Password = "Mudar@123Senha",
                UserName = "francisca"
            });

            listUsers.Add(new Users
            {
                Id = Guid.NewGuid(),
                Email = "user5@email.com",
                Name = "Camila",
                Password = "Mudar@123Senha",
                UserName = "camila"
            });

            return listUsers;
        }
    }
}
