using BlueModas.API.Domain.Entidades;
using BlueModas.API.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.API.Domain.Interface
{
    public interface IClienteRepository
    {
        Task<ActionResult<IEnumerable<Cliente>>> GetAll();
        Task<Cliente> GetById(Guid id);
        RetornosEnum Update(Guid id, Cliente cliente);
        Task<Cliente> Add(Cliente cliente);
        Task<Cliente> Delete(Guid id);
    }
}
