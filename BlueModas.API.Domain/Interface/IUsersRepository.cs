using BlueModas.API.Domain.Entidades;
using BlueModas.API.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueModas.API.Domain.Interface
{
    public interface IUsersRepository
    {
        Task<ActionResult<IEnumerable<Users>>> GetAll();
        Task<Users> GetById(Guid id);
        RetornosEnum Update(Guid id, Users users);
        Task<Users> Add(Users users);
        Task<Users> Delete(Guid id);
    }
}
