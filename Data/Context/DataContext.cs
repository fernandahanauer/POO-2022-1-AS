using Data.Types;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Cliente> DbSetCliente { get; set; }
        public DbSet<Vendedor> DbSetVendedor { get; set; }
        public DbSet<Pedido> DbSetPedido { get; set; }
        public DbSet<Categoria> DbSetCategoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }

    }
}