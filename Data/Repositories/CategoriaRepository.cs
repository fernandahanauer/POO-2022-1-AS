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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext _context;
        public CategoriaRepository(DataContext context)
        {
            _context = context;
        }

        public bool Delete(int idEntity)
        {
            var categoria = _context.DbSetCategoria.FirstOrDefault(i => i.Id == idEntity);
            if (categoria == null)
                return false;
            else
            {
                _context.DbSetCategoria.Remove(categoria);
                return true;
            }
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            return await _context.DbSetCategoria.ToListAsync();
        }

        public async Task<Categoria> GetByIdAsync(int id)
        {
            return await _context.DbSetCategoria.SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Save(Categoria t) => _context.Add(t);


        public void Update(Categoria t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }
    }
}
