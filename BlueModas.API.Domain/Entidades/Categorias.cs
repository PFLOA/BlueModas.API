using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.API.Domain.Entidades
{
    public class Categorias
    {
        #region [ Attributes ]
        private int _id;
        private string _nome; 
        #endregion

        #region [ Properties ]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        } 
        #endregion
    }
}
