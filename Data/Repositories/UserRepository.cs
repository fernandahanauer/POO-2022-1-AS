using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext Context;
        public UserRepository(DataContext context)
        {
            this.Context = context;
        }
        public void Delete(int entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Save(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}