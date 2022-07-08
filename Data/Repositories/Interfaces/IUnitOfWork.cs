using Data.Repositories.Interfaces;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        IClienteRepository ClienteRepository {get;}
        ICategoriaRepository CategoriaRepository {get;}
        IPedidoRepository PedidoRepository {get;}
        IProdutoRepository ProdutoRepository {get;}
        IVendedorRepository VendedorRepository {get;}
    }
}