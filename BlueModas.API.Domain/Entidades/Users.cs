using BlueModas.API.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlueModas.API.Domain.Entidades
{
    /// <summary>
    /// Entidade de Usuário da aplicação.
    /// </summary>
    public class Users : Login
    {
        #region [ Attributes ]
        private string _name;
        private DateTime _dataCadastro;
        private NivelAcesso _nivelAcesso;
        #endregion

        #region [ Properties ]
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
        /// Data de cadastro do usuário no sistema.
        /// </summary>
        public DateTime DataCadastro
        {
            get { return _dataCadastro; }
            set { _dataCadastro = value; }
        }

        public NivelAcesso NivelAcesso
        {
            get { return _nivelAcesso; }
            set { _nivelAcesso = value; }
        }
        #endregion
    }
}
