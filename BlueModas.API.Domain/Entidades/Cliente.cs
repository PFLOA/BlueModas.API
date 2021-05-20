using BlueModas.API.Domain.Filters;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlueModas.API.Domain.Entidades
{
    [SwaggerSchemaFilter(typeof(AddSchemaFilter))]
    public class Cliente : Login
    {
        #region [ Attributes ]
        private string _name;
        private DateTime _dataCadastro;
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
        /// <summary>
        /// Lista de telefones do usuário.
        /// </summary>
        public virtual ICollection<Telefone> Telefones { get; set; }
        /// <summary>
        /// Lista de endereços do usuário.
        /// </summary>
        public virtual ICollection<Endereco> Enderecos { get; set; }
        #endregion
    }
}
