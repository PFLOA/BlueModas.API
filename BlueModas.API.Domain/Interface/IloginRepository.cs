using BlueModas.API.Domain.Entidades;
using System.Threading.Tasks;

namespace BlueModas.API.Domain.Interface
{
    public interface ILoginRepository
    {
        Task<Users> LoginUser(Login login);
    }
}