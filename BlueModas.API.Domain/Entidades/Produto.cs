using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.API.Domain.Entidades
{
    public class Produto
    {
        #region [ Attributes ]
        private int _id;
        private Categorias _categorias;
        private double _preco;
        private byte _imagem;
        private string _descricao;
        #endregion

        #region [ Properties ]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public double Preco
        {
            get { return _preco; }
            set { _preco = value; }
        }

        public byte Imagem
        {
            get { return _imagem; }
            set { _imagem = value; }
        }

        public Categorias Categorias
        {
            get { return _categorias; }
            set { _categorias = value; }
        }

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        #endregion
    }
}
