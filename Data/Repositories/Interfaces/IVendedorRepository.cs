using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IVendedorRepository : IBaseRepository<Vendedor>
    {
        Task<IEnumerable<VendedorDto>> GetVendedores();
    }
}