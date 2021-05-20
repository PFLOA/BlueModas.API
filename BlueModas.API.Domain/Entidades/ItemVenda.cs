using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.API.Domain.Entidades
{
    public class ItemVenda
    {
        #region [ Attributes ]
        private int _id;
        private int _produtoId;
        private int _quantidade;
        private Produto produtos;
        #endregion

        #region [ Properties ]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Id do Produto.
        /// </summary>
        public int ProdutoId
        {
            get { return _produtoId; }
            set { _produtoId = value; }
        }
        /// <summary>
        /// Produto.
        /// </summary>
        public Produto Produto
        {
            get { return produtos; }
            set { produtos = value; }
        }
        /// <summary>
        /// Quantidade de itens.
        /// </summary>
        public int Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        } 
        #endregion
    }
}
