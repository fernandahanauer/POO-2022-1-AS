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
            throw new NotImplementedException();
        }

        public Task<List<Vendedor>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Vendedor> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Vendedor t)
        {
            throw new NotImplementedException();
        }

        public void Update(Vendedor t)
        {
            throw new NotImplementedException();
        }
    }