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
            throw new NotImplementedException();
        }

        public Task<List<Pedido>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Pedido t)
        {
            throw new NotImplementedException();
        }

        public void Update(Pedido t)
        {
            throw new NotImplementedException();
        }
    }
}