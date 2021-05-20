using System;

namespace BlueModas.API.Domain.Entidades
{
    public class Venda
    {
        #region [ Attributes ]
        private int _id;
        private Cliente _cliente;
        private Produto _produto;
        #endregion

        #region [ Properties ]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Guid ClienteId { get; set; }
        public Guid ProdutoId { get; set; }
        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        public Produto Produto
        {
            get { return _produto; }
            set { _produto = value; }
        }
        #endregion
    }
}
