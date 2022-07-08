using Data.Context;
using Data.Repositories.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;
        public ClienteRepository(DataContext context)
        {
            _context = context;
        }

        public bool Delete(int idEntity)
        {
            var cliente = _context.DbSetCliente.FirstOrDefault(i => i.Id == idEntity);

            if (cliente == null)
                return false;
            else
            {
                _context.DbSetCliente.Remove(cliente);
                return true;
            }
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.DbSetCliente.ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.DbSetCliente.SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Save(Cliente t)
        {
            _context.DbSetCliente.Add(t);
        }

        public void Update(Cliente t)
        {
            _context.Entry(t).State = EntityState.Modified;

        }
    }
}