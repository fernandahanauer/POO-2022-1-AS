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
    public class CategoriaRepository : BaseRepository, ICategoriaRepository
    {
        private readonly DataContext _context;
        public CategoriaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoriaDto>> GetCategoriasAsync()
        {
            return await _context.DbSetCategoria
                .Select(x => new CategoriaDto { Id = x.Id, Nome = x.Nome })
                .ToListAsync();
        }

        public async Task<Categoria> GetCategoriasByIdAsync(int id)
        {
                return await _context.DbSetCategoria
                .Include(x => x.Produtos)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
