using BlueModas.API.Domain.Filters;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BlueModas.API.Domain.Entidades
{
    [SwaggerSchemaFilter(typeof(AddSchemaFilter))]
    public class Produto
    {
        #region [ Properties ]
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }
        public Categorias Categoria { get; set; }
        #endregion
    }
}
