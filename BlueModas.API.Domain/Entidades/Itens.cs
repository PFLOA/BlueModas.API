using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BlueModas.API.Domain.Entidades
{
    public class Itens
    {
        public int Id { get; set; }
        public int IdVenda { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }

        [JsonIgnore]
        public virtual Venda Venda { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
