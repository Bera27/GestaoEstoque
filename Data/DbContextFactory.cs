using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoque.Data
{
    public static class DbContextFactory
    {
        private static readonly DbContextOptions<GestaoEstoqueDataContext> _options;

        static DbContextFactory()
        {
            var options = new DbContextOptionsBuilder<GestaoEstoqueDataContext>();
            options.UseSqlServer("Server=localhost,1433;Database=GestaoEstoque;User ID=sa;Password=1q2w3e4r@#$;Encrypt=True;TrustServerCertificate=True");

            _options = options.Options;
        }

        public static GestaoEstoqueDataContext CreateDbContext()
        {
            return new GestaoEstoqueDataContext(_options);
        }
    }
}