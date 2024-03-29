using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories.Interfaces
{
    public interface IPedidoRepository : IBaseRepository<Pedido>
    {
        Task<PedidoProduto> GetPedidoprodutoAsync(int pedidoId, int produtoId);
    }
    
}