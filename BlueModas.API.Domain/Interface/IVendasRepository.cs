using BlueModas.API.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.API.Domain.Interface
{
    public interface IVendasRepository
    {
        Task<Venda> Add(Venda venda);
        Task<Venda> GetById(int id);
        Task<ActionResult<IEnumerable<Venda>>> GetAll();
    }
}
