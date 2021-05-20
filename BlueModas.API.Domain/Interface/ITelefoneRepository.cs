using BlueModas.API.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.API.Domain.Interface
{
    public interface ITelefoneRepository
    {
        Task<ActionResult<IEnumerable<Telefone>>> GetAll();
    }
}
