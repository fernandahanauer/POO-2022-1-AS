using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories.Interfaces
{
    public interface IPedidoRepository : IBaseRepository
    {
        Task<IEnumerable<PedidoDto>> GetPedidosAsync();
        Task<Pedido> GetPedidosByIdAsync(int id);
        Task<PedidoProduto> GetPedidoProdutoAsync(int pedidoId, int produtoId);
    }
    
}