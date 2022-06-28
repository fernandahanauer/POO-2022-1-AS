using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _Context;

        public UnitOfWork(DataContext context)
        {
            this._Context = context;
        }
        
        public async Task CommitAsync()
        {
            await _Context.SaveChangesAsync();
        }

        private IUserRepository _UserREpository;
        public IUserRepository UserRepository
        {
            get {return _UserREpository ??= new UserRepository(_Context);}
        }
    }
}