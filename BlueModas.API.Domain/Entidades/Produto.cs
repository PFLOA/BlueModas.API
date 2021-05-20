using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.API.Domain.Entidades
{
    public class Produto
    {
        #region [ Attributes ]
        private Guid _id;
        private Categorias _categorias;
        private decimal _preco;
        private byte _imagem;
        private string _descricao;
        private string _nome;
        #endregion

        #region [ Properties ]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public decimal Preco
        {
            get { return _preco; }
            set { _preco = value; }
        }
        public byte Imagem
        {
            get { return _imagem; }
            set { _imagem = value; }
        }
        public int CategoriaId { get; set; }
        public Categorias Categoria
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
