using BlueModas.API.Domain.Entidades;
using BlueModas.API.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.API.Domain.Interface
{
    public interface ICategoriaRepository
    {
        Task<ActionResult<IEnumerable<Categorias>>> GetAll();
        Task<Categorias> GetById(int id);
        RetornosEnum Update(int id, Categorias categorias);
        Task<Categorias> Add(Categorias categorias);
        Task<Categorias> Delete(int id);
    }
}
