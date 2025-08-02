using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoEstoque.Data.Mappings
{
    public class OrderItensMap : IEntityTypeConfiguration<OrderItens>
    {
        public void Configure(EntityTypeBuilder<OrderItens> builder)
        {
            builder.ToTable("OrderItens");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Amount)
                .IsRequired()
                .HasColumnName("Amount")
                .HasColumnType("INT");

            builder.Property(x => x.PriceUnit)
                .IsRequired()
                .HasColumnName("PriceUnit")
                .HasColumnType("Decimal");

            // Relacionamentos
            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderItens)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.OrderItens)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}