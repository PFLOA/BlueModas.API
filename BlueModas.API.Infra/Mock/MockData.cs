using BlueModas.API.Domain.Entidades;
using BlueModas.API.Infra.Data;
using BlueModas.API.Infra.Mock.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.API.Infra.Mock
{
    public class MockData
    {
        public static void Add(BlueModasDbContext blueModasDbContext)
        {
             blueModasDbContext.Categorias.AddRange(RetornoListMockJson<Categorias>.RetornoList("./JSON/categorias.json"));
             blueModasDbContext.Users.AddRange(RetornoListMockJson<Users>.RetornoList("./JSON/users.json"));
             blueModasDbContext.Produto.AddRange(RetornoListMockJson<Produto>.RetornoList("./JSON/produtos.json"));

            blueModasDbContext.SaveChanges();
        }
    }
}
