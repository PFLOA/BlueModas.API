using BlueModas.API.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.API.Domain.Interface
{
    public interface IVendasRepository
    {
        Task<Venda> Add(Venda venda);
    }
}
