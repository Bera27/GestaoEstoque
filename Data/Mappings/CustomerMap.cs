using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoEstoque.Data.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Custumer");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasColumnName("Phone")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(20);

            builder.Property(x => x.Address)
                .IsRequired()
                .HasColumnName("Address")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.State)
                .IsRequired()
                .HasColumnName("State")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.Cep)
                .IsRequired()
                .HasColumnName("Cep")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(10);

            builder.Property(x => x.DateRegistration)
                .IsRequired()
                .HasColumnName("DateRegistration")
                .HasColumnType("SMALLDATETIME")
                .HasMaxLength(60)
                .HasDefaultValue(DateTime.Now);

            builder
                .HasIndex(x => x.Email, "IX_Customer_Email")
                .IsUnique();

            // Relacionamentos
            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);       
        }
    }
}