using Data.Context;
using Data.Repositories.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;
        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }

        public bool Delete(int idEntity)
        {
            var producto = _context.DbSetProduto.FirstOrDefault(i => i.Id == idEntity);
            if (producto == null)
                return false;
            else
            {
                _context.DbSetProduto.Remove(producto);
                return true;
            }
        }

        public async Task<List<Produto>> GetAllAsync()
        {
            return await _context.DbSetProduto.ToListAsync();
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            return await _context.DbSetProduto.SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Save(Produto t) => _context.Add(t);


        public void Update(Produto t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }
    }
}