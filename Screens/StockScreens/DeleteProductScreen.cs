using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoque.Screens.StockScreens
{
    public static class DeleteProductScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir produto");
            Console.WriteLine();
            Console.WriteLine("Informe o Id do produto:");
            int id = int.Parse(Console.ReadLine());
            Delete(id);
            Console.ReadKey();
            MenuStockScreen.Load();
        }

        public static void Delete(int id)
        {
            using var context = DbContextFactory.CreateDbContext();

            try
            {
                var product = context.Products
                .Include(x => x.Stock)
                .FirstOrDefault(x => x.Id == id);

                if (product == null)
                {
                    Console.WriteLine("Produto não encontrado");
                    return;
                }

                Console.WriteLine($"Nome: {product.Name} | Preço de compra: {product.PricePurchase:C} | Preço de venda: {product.PriceSale:C} | Qtd: {product.Stock.Amount} | Descrição: {product.Description} | Total: {product.PricePurchase * product.Stock.Amount:C}");
                Console.WriteLine("Esse é o pruduto desejado? S/N");
                string option = Console.ReadLine().Substring(0, 1).ToUpper();

                if (option == "S")
                {
                    context.Remove(product);
                    context.SaveChanges();
                    Console.WriteLine("Produto excluido com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel Excluir");
                Console.WriteLine(ex.Message);
            }
        }
    }
}