using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories.Interfaces
{
    public interface IClienteRepository : IBaseRepository
    {
        Task<IEnumerable<ClienteDto>> GetClientesAsync();
        Task<Cliente> GetClientesByIdAsync(int id);
    }
}