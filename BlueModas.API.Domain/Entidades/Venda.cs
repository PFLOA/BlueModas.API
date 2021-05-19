using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.API.Domain.Entidades
{
    class Venda
    {
        #region [ Attributes ]
        private int _id;
        private List<ItenVenda> _itensVenda;
        private Cliente _cliente;
        #endregion

        #region [ Properties ]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }


        public List<ItenVenda> ItensVenda
        {
            get { return _itensVenda; }
            set { _itensVenda = value; }
        } 
        #endregion
    }
}
