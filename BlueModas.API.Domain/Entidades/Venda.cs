using BlueModas.API.Domain.Filters;
using BlueModas.API.Filters;
using BlueModas.API.Filters.Vendas;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace BlueModas.API.Domain.Entidades
{
    [SwaggerSchemaFilter(typeof(AddSchemaFilter))]
    public class Venda
    {
        #region [ Properties ]
        public Cliente Cliente { get; set; }
        public int Id { get; set; }
        public Guid ClienteId { get; set; }
        public decimal TotalVenda
        {
            get
            {
                var total = Itens.Sum(p => p.Quantidade * p.Produto.Preco);
                return total;
            }
        }
        public virtual List<Itens> Itens { get; set; }
        #endregion
    }
}
