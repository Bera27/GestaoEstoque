using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoEstoque.Data.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.DateOrder)
                .IsRequired()
                .HasColumnName("DateOrder")
                .HasColumnType("SMALLDATETIME")
                .HasMaxLength(60)
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.ValueTotal)
                .IsRequired()
                .HasColumnName("ValueTotal")
                .HasColumnType("Decimal");

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnName("Status")
                .HasColumnType("INT");
        }
    }
}