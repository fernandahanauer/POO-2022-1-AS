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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;
        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }

        public bool Delete(int idEntity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Produto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Produto t)
        {
            throw new NotImplementedException();
        }

        public void Update(Produto t)
        {
            throw new NotImplementedException();
        }
    }
}