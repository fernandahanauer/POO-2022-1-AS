using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Types
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pedido> builder)
        {
             builder.ToTable("pedido");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.DataCompra)
                .HasColumnName("dataCompra")
                .HasColumnType("DATE")
                .IsRequired();

            builder.Property(i => i.ValorTotal)
                .HasColumnName("valorTotal")
                .HasColumnType("DECIMAL")
                .IsRequired();

            builder.Property(i => i.ValorTotalDes)
                .HasColumnName("valorTotalDes")
                .HasColumnType("DECIMAL")
                .IsRequired();
                  
            builder.Property(i => i.ClienteId)
                .HasColumnName("clienteId")
                .HasColumnType("INT")
                .IsRequired();

            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.Pedidos)
                .HasConstraintName("FK_Pedido_Cliente")
                .OnDelete(DeleteBehavior.Restrict);


            builder.Property(i => i.VendedorId)
                .HasColumnName("VendedorId")
                .HasColumnType("INT")
                .IsRequired();

                
            builder.HasOne(x => x.Vendedor)
                .WithMany(x => x.Pedidos)
                .HasConstraintName("FK_Pedido_Vendedor")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}