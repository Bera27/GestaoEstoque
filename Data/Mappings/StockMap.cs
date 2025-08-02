using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoEstoque.Data.Mappings
{
    public class StockMap : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stock");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Amount)
                .IsRequired()
                .HasColumnName("Amount")
                .HasColumnType("INT");

            builder.Property(x => x.LastUpdate)
                .IsRequired()
                .HasColumnName("LastUpdate")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValue(DateTime.Now);

            // Relacionamentos
            builder.HasOne(x => x.Product)
                .WithMany(x => x.Stocks)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}