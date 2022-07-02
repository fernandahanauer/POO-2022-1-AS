using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories.Interfaces
{
    public interface ICategoriaRepository : IBaseRepository
    {
        Task<IEnumerable<CategoriaDto>> GetCategoriasAsync();
        Task<Categoria> GetCategoriasByIdAsync(int id);
    }
}