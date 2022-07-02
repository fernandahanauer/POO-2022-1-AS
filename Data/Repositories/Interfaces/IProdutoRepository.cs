using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories.Interfaces
{
    public interface IProdutoRepository : IBaseRepository
    {
        Task<IEnumerable<ProdutoDto>> GetProdutosAsync();
        Task<Produto> GetProdutosByIdAsync(int id);
    }
}