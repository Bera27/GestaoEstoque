using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoEstoque.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.PricePurchase)
                .IsRequired()
                .HasColumnName("PricePurchase")
                .HasColumnType("DECIMAL");

            builder.Property(x => x.PriceSale)
                .IsRequired()
                .HasColumnName("PriceSale")
                .HasColumnType("DECIMAL");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("TEXT")
                .HasMaxLength(1000);
        }
    }
}