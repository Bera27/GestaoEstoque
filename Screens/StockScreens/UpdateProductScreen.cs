using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Data;
using GestaoEstoque.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoque.Screens.StockScreens
{
    public static class UpdateProductScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar produto");
            Console.WriteLine();

            Console.Write("ID do produto: ");
            int id = int.Parse(Console.ReadLine());

            Get(id);
            Console.Clear();

            Console.Write("Novo nome: ");
            string name = Console.ReadLine();

            Console.Write("Preço de compra: ");
            decimal pricePurchase = decimal.Parse(Console.ReadLine());

            Console.Write("Preço de venda: ");
            decimal priceSale = decimal.Parse(Console.ReadLine());

            Console.Write("Descrição: ");
            string description = Console.ReadLine();

            Console.Write("Quantidade em estoque: ");
            int amount = int.Parse(Console.ReadLine());

            Update(id, name, pricePurchase, priceSale, description, amount);
            Console.ReadKey();
            MenuStockScreen.Load();
        }


        public static void Get(int id)
        {
            using var context = DbContextFactory.CreateDbContext();
            var findProd = context.Products
                .Include(x => x.Stock)
                .FirstOrDefault(x => x.Id == id);

            if (findProd == null)
            {
                Console.WriteLine($"Não tem nenhum produto com esse ID: '{id}' ");
                Console.ReadKey();
                MenuStockScreen.Load();
            }

            Console.WriteLine($"Nome: {findProd.Name} | Preço de compra: {findProd.PricePurchase:C} | Preço de venda: {findProd.PriceSale:C} | Qtd: {findProd.Stock.Amount} | Descrição: {findProd.Description} | Total: {findProd.PricePurchase * findProd.Stock.Amount:C}");
            Console.WriteLine("Esse é o pruduto desejado? S/N");
            string option = Console.ReadLine().Substring(0, 1).ToUpper();

            if (option == "N")
                return;
            
        }
        public static void Update(int id, string name, decimal pricePurchase, decimal priceSale, string description, int amount)
        {
            using var context = DbContextFactory.CreateDbContext();

            try
            {
                var findProd = context.Products
                .Include(x => x.Stock)
                .FirstOrDefault(x => x.Id == id);

                findProd.Name = name;
                findProd.PricePurchase = pricePurchase;
                findProd.PriceSale = priceSale;
                findProd.Description = description;
                findProd.Stock.Amount = amount;

                context.SaveChanges();
                Console.WriteLine("Produto atualizado com sucesso");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel atualizar!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}