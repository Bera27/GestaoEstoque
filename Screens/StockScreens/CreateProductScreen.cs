using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Data;
using GestaoEstoque.Models;

namespace GestaoEstoque.Screens.StockScreens
{
    public static class CreateProductScreen
    {
        public static void Load()
        {
            Create();
        }

        public static void Create()
        {
            try
            {
                using var context = DbContextFactory.CreateDbContext();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel Cadastrar!");
                Console.WriteLine(ex.Message);
            }

            
        }
    }
}