using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly DataContext _context;
        public VendedorRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(int entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Vendedor>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Vendedor> GetByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VendedorDto>> GetVendedores()
        {
            return await _context.DbSetVendedor.Select(x => new VendedorDto{Id = x.Id, Nome = x.Nome, Bonificacao = x.Bonificacao }).ToListAsync();
        }

        public void Save(Vendedor entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Vendedor entity)
        {
            throw new NotImplementedException();
        }
    }
}