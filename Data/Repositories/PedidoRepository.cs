using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Repositories.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PedidoRepository : BaseRepository, IPedidoRepository
    {
        private readonly DataContext _context;
        public PedidoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Pedido> GetPedidosByIdAsync(int id)
        {
            return await _context.DbSetPedido
                .Include(x => x.Produtos)
                .Include(x => x.Vendedor)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PedidoDto>> GetPedidosAsync()
        {
            return await _context.DbSetPedido
                .Select(x => new PedidoDto { Id = x.Id, 
                                            DataCompra = x.DataCompra, 
                                            ValorTotal = x.ValorTotal })
                .ToListAsync();
        }

        public Task<PedidoProduto> GetPedidoProdutoAsync(int pedidoId, int produtoId)
        {
            throw new NotImplementedException();
        }
    }
}