using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoque.Screens.OrderScreens
{
    public class GetOrderScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Informe o ID do pedido:");
            int id = int.Parse(Console.ReadLine());
            Get(id);
            Console.ReadKey();
            MenuOrderScreen.Load();
        }

        public static void Get(int id)
        {
            using var context = DbContextFactory.CreateDbContext();

            var order = context.Orders
                .Include(c => c.Customer)
                .Include(o => o.OrderItens)
                    .ThenInclude(p => p.Product)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
                return;

            Console.WriteLine($"Cliente: {order.Customer.Email} | Total: {order.ValueTotal:C} | Data do pedido: {order.DateOrder:d} | Status: {order.Status}");
            Console.WriteLine();
            Console.WriteLine("Itens do pedido:");

            foreach (var itens in order.OrderItens)
            {
                Console.WriteLine($@"Produto: {itens.Product.Name} | Preço: {itens.Product.PriceSale:C} | Quantidade {itens.Amount} | Total: {itens.Product.PriceSale * itens.Amount:C}");
            }
        }
    }
}