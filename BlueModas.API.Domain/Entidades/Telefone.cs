using BlueModas.API.Domain.Enum;

namespace BlueModas.API.Domain.Entidades
{
    public class Telefone
    {
        #region [ Attributes ]
        private int _id;
        private TipoTelefone _tipoTelefone;
        private Users _users;
        private string _numero; 
        #endregion

        #region [ Properties ]
        /// <summary>
        /// Id do telefone.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Users Users
        {
            get { return _users; }
            set { _users = value; }
        }

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