using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using GestaoEstoque.Data;
using GestaoEstoque.Models;

namespace GestaoEstoque.Screens.StockScreens
{
    public static class CreateProductScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Produto");
            Console.WriteLine();
            Console.WriteLine("Nome:");
            string name = Console.ReadLine();

            Console.WriteLine("Descrição:");
            string description = Console.ReadLine();

            Console.WriteLine("Preço de compra:");
            decimal pricePurchase = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Preço de venda:");
            decimal priceSale = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Quantidade em estoque:");
            int amount = int.Parse(Console.ReadLine());

            var product = new Product
            {
                Name = name,
                Description = description,
                PricePurchase = pricePurchase,
                PriceSale = priceSale
            };

            Create(product, amount);
            Console.ReadKey();
            MenuStockScreen.Load();
        }

        public static void Create(Product product, int amount)
        {
            using var context = DbContextFactory.CreateDbContext();
            using var transaction = context.Database.BeginTransaction(); 

            try
            {
                context.Add(product);
                context.SaveChanges();

                var stock = new Stock
                {
                    ProductId = product.Id,
                    Amount = amount
                };

                context.Add(stock);
                context.SaveChanges();

                transaction.Commit();
                Console.WriteLine("Cadastro realizado com sucesso!");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("Não foi possivel Cadastrar!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}