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

        public bool Delete(int idEntity)
        {
            var vendedor = _context.DbSetVendedor.FirstOrDefault(i => i.Id == idEntity);
            if (vendedor == null)
                return false;
            else
            {
                _context.DbSetVendedor.Remove(vendedor);
                return true;
            }
        }

        public async Task<List<Vendedor>> GetAllAsync()
        {
            return await _context.DbSetVendedor.ToListAsync();
        }

        public async Task<Vendedor> GetByIdAsync(int id)
        {
            return await _context.DbSetVendedor.SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Save(Vendedor t) => _context.Add(t);


        public void Update(Vendedor t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }
    }
}