using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Data.Mappings;
using GestaoEstoque.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoque.Data
{
    public class GestaoEstoqueDataContext : DbContext
    {
        public GestaoEstoqueDataContext(DbContextOptions<GestaoEstoqueDataContext> options)
            : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost,1433;Database=GestaoEstoque;User ID=sa;Password=1q2w3e4r@#$;Encrypt=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderItensMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new StockMap());
        }
    }
}