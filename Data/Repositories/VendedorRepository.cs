using Data.Context;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class VendedorRepository : BaseRepository, IVendedorRepository
    {
        private readonly DataContext _context;
        public VendedorRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Vendedor> GetVendedorByIdAsync(int id)
        {
                return await _context.DbSetVendedor
                .Include(x => x.Pedidos)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<VendedorDto>> GetVendedoresAsync()
        {
            return await _context.DbSetVendedor
                .Select(x => new VendedorDto {Id = x.Id, Nome = x.Nome, Bonificacao = x.Bonificacao})
                .ToListAsync();
        }
    }
}