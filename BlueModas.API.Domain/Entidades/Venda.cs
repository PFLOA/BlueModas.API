using BlueModas.API.Filters;
using BlueModas.API.Filters.Vendas;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlueModas.API.Domain.Entidades
{
    [SwaggerSchemaFilter(typeof(VendasAddSchemaFilter))]
    public class Venda
    {
        #region [ Properties ]
        public Cliente Cliente { get; set; }
        public int Id { get; set; }
        public Guid ClienteId { get; set; }
        public virtual List<Itens> Itens { get; set; }
        #endregion
    }
}
