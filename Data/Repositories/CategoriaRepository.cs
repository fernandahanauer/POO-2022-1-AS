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
            throw new NotImplementedException();
        }

        public Task<List<Categoria>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Categoria t)
        {
            throw new NotImplementedException();
        }

        public void Update(Categoria t)
        {
            throw new NotImplementedException();
        }
    }
}
