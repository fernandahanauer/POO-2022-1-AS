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
            return await _context.DbSetPedido.SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Save(Pedido t) => _context.Add(t);


        public void Update(Pedido t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }
    }
}