using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Data;
using GestaoEstoque.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoque.Screens.StockScreens
{
    public static class GetAllProductScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Estoque");
            Console.WriteLine();
            GetAll();
            Console.ReadKey();
            MenuStockScreen.Load();
        }

        public static void GetAll()
        {
            using var context = DbContextFactory.CreateDbContext();

            var products = context.
                Products.
                AsNoTracking()
                .Include(x => x.Stock)
                .ToList();

            foreach (var p in products)
            {
                Console.WriteLine($"ID: {p.Id} - Nome: {p.Name} | Preço de compra: {p.PricePurchase:C} | Preço de venda: {p.PriceSale:C} | Qtd: {p.Stock.Amount} | Descrição: {p.Description} | Total: {p.PricePurchase * p.Stock.Amount:C}");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------");
            }
        }
    }
}