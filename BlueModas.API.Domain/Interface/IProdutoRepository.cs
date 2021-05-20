using BlueModas.API.Domain.Entidades;
using BlueModas.API.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.API.Domain.Interface
{
    public interface IProdutoRepository
    {
        Task<ActionResult<IEnumerable<Produto>>> GetAll();
        Task<Produto> GetById(int id);
        RetornosEnum Update(int id, Produto produto);
        Task<Produto> Add(Produto produto);
        Task<Produto> Delete(int id);
    }
}
