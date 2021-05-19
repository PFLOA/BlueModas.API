using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlueModas.API.Domain.Entidades
{
    public class Cliente
    {
        #region [ Attributes ]
        private Guid _id;
        private string _name;
        private string _userName;
        private string _email;
        private string _password;
        private DateTime _dataCadastro;
        private List<Telefone> _telefones;
        private List<Endereco> _enderecos;
        #endregion

        #region [ Properties ]
        /// <summary>
        /// Id do usuário.
        /// </summary>
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Nome completo do usuário.
        /// </summary>
        [Required(ErrorMessage = "Campo Name é obrigatório !")]
        public string Name
        {
            get { return _name.ToUpper(); }
            set { _name = value; }
        }
        /// <summary>
        /// UserName utilizado para gerar login na aplicação.
        /// </summary>
        [Required(ErrorMessage = "Campo UserName é obrigatório !")]
        [DataType(DataType.Password)]
        public string UserName
        {
            get { return _userName.ToUpper(); }
            set { _userName = value; }
        }
        /// <summary>
        /// Senha utilizada para gerar login na aplicação.
        /// </summary>
        [Required(ErrorMessage = "Campo Password é obrigatório !")]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// Email do usuário.
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// Data de cadastro do usuário no sistema.
        /// </summary>
        public DateTime DataCadastro
        {
            get { return _dataCadastro; }
            set { _dataCadastro = value; }
        }
        /// <summary>
        /// Lista de telefones do usuário.
        /// </summary>
        public virtual List<Telefone> Telefones
        {
            get { return _telefones; }
            set { _telefones = value; }
        }
        /// <summary>
        /// Lista de endereços do usuário.
        /// </summary>
        public virtual List<Endereco> Enderecos
        {
            get { return _enderecos; }
            set { _enderecos = value; }
        }
        #endregion
    }
}
