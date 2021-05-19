using BlueModas.API.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace BlueModas.API.Domain.Entidades
{
    public class Endereco
    {
        #region [ Attributes ]
        private int _id;
        private Users _users;
        private string _rua;
        private string _numero;
        private string _complemento;
        private string _bairro;
        private string _cep;
        private string _cidade;
        private string _estado;
        private string _observações;
        private TipoEndereco _tipoEndereco;
        #endregion

        #region [ Properties ]
        /// <summary>
        /// Id do Endereço.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Id do Usuário.
        /// </summary>
        public Users Users
        {
            get { return _users; }
            set { _users = value; }
        }
        /// <summary>
        /// Rua sem o numero.
        /// </summary>
        [Required(ErrorMessage = "Obrigatório passar o endereço de entrega.")]
        public string Rua
        {
            get { return _rua; }
            set { _rua = value; }
        }
        /// <summary>
        /// Numero do endereço.
        /// </summary>
        [Required(ErrorMessage = "Obrigatório passar o numero do endereço para entrega.")]
        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        /// <summary>
        /// Complemento para o endereço
        /// </summary>
        public string Complemento
        {
            get { return _complemento; }
            set { _complemento = value; }
        }
        /// <summary>
        /// Bairro.
        /// </summary>
        [Required(ErrorMessage = "Obrigatório passar o Bairro de entrega")]
        public string Bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }
        /// <summary>
        /// Cep com qualquer formato.
        /// </summary>
        [Required(ErrorMessage = "Obrigatório passar o Cep de entrega")]
        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }
        /// <summary>
        /// Cidade.
        /// </summary>
        [Required(ErrorMessage = "Obrigatório passar a Cidade de entrega")]
        public string Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }
        /// <summary>
        /// Estado no formato de sigla.
        /// </summary>
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        /// <summary>
        /// Observações adicionais.
        /// </summary>
        public string Observacoes
        {
            get { return _observações; }
            set { _observações = value; }
        }
        /// <summary>
        /// Tipo do endereço, Cobrança, Comercial, Entrega, Padrão: Entrega.
        /// </summary>
        public TipoEndereco TipoEndereco
        {
            get { return _tipoEndereco; }
            set { _tipoEndereco = value; }
        } 
        #endregion
    }
}