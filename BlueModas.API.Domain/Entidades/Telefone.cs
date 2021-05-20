using BlueModas.API.Domain.Enum;
using System;
using System.Text.Json.Serialization;

namespace BlueModas.API.Domain.Entidades
{
    public class Telefone
    {
        #region [ Attributes ]
        private int _id;
        private TipoTelefone _tipoTelefone;
        private Cliente _cliente;
        private string _numero;
        #endregion

        #region [ Properties ]
        /// <summary>
        /// Id do Usuário.
        /// </summary>
        [JsonIgnore]
        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        /// <summary>
        /// Id do telefone.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Guid ClienteId { get; set; }
        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        public TipoTelefone TipoTelefone
        {
            get { return _tipoTelefone; }
            set { _tipoTelefone = value; }
        } 
        #endregion
    }
}