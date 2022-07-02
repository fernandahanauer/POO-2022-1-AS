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
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        private readonly DataContext _context;
        public ProdutoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProdutoDto>> GetProdutosAsync()
        {
            return await _context.DbSetProduto
                .Select(x => new ProdutoDto { Id = x.Id, Nome = x.Nome, Preco = x.Preco})
                .ToListAsync();
        }

        public async Task<Produto> GetProdutosByIdAsync(int id)
        {
             return await _context.DbSetProduto
                .Include(x => x.Categoria)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    
    }
}