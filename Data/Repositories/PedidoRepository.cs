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
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DataContext _context;
        public PedidoRepository(DataContext context)
        {
            _context = context;
        }

       public bool Delete(int idEntity)
        {
            var pedido = _context.DbSetPedido.FirstOrDefault(i => i.Id == idEntity);
            if (pedido == null)
                return false;
            else
            {
                _context.DbSetPedido.Remove(pedido);
                return true;
            }
        }

        public async Task<List<Pedido>> GetAllAsync()
        {
            return await _context.DbSetPedido.ToListAsync();
        }

        public async Task<Pedido> GetByIdAsync(int id)
        {
            return await _context.DbSetPedido
                .Include(x => x.Produtos)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void Save(Pedido t) => _context.Add(t);


        public void Update(Pedido t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }

        public async Task<PedidoProduto> GetPedidoprodutoAsync(int pedidoId, int produtoId)
        {
            return await _context.DbSetPedidoProduto
                .Where(x => x.PedidoId == pedidoId && x.ProdutoId == produtoId)
                .FirstOrDefaultAsync();
        }
    }
}