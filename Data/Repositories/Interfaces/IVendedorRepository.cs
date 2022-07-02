using Domain.Dtos;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IVendedorRepository : IBaseRepository
    {
        Task<IEnumerable<VendedorDto>> GetVendedoresAsync();
        Task<Vendedor> GetVendedorByIdAsync(int id);
    }
}