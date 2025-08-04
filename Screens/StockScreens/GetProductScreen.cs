using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Data;
using GestaoEstoque.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoque.Screens.StockScreens
{
    public static class GetProductScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Busca de produto");
            Console.WriteLine();
            Console.WriteLine("Qual o nome do produto:");
            string name = Console.ReadLine();

            Get(name);
            Console.ReadKey();
            MenuStockScreen.Load();
        }

        public static void Get(string name)
        {
            using var context = DbContextFactory.CreateDbContext();

            try
            {
                var product = context.Products
                .Include(x => x.Stock)
                .FirstOrDefault(x => x.Name == name);

                if (product == null)
                {
                    Console.WriteLine($"Produto '{name}' não encontrado no estoque");
                    Console.ReadKey();
                    MenuStockScreen.Load();
                }

                Console.WriteLine($"ID: {product.Id} - Nome: {product.Name} | Preço de compra: {product.PricePurchase:C} | Preço de venda: {product.PriceSale:C} | Qtd: {product.Stock.Amount} | Descrição: {product.Description} | Total: {product.PricePurchase * product.Stock.Amount:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}