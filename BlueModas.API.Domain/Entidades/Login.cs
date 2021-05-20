using BlueModas.API.Domain.Filters;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlueModas.API.Domain.Entidades
{
    [SwaggerSchemaFilter(typeof(AddSchemaFilter))]
    public class Login
    {
        public Guid Id { get; set; }

        /// <summary>
        /// UserName utilizado para gerar login na aplicação.
        /// </summary>
        [Required(ErrorMessage = "Campo UserName é obrigatório !")]
        [DataType(DataType.Password)]
        public string UserName { get; set; }

        /// <summary>
        /// Senha utilizada para gerar login na aplicação.
        /// </summary>
        [Required(ErrorMessage = "Campo Password é obrigatório !")]
        public string Password { get; set; }
        /// <summary>
        /// Email do usuário.
        /// </summary>
        public string Email { get; set; }
    }
}
