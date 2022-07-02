
using Data.Context;
using Data.Repositories.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        private readonly DataContext _context;
        public ClienteRepository(DataContext context) : base(context)
        {
            _context = context;
        }

       public async Task<IEnumerable<ClienteDto>> GetClientesAsync()
        {
            return await _context.DbSetCliente
                .Select(x => new ClienteDto { Id = x.Id, Nome = x.Nome })
                .ToListAsync();
        }

        public async Task<Cliente> GetClientesByIdAsync(int id)
        {
            return await _context.DbSetCliente
                .Include(x => x.Pedidos)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

    }
}