using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoque.Screens.OrderScreens
{
    public class GetAllOrderScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Pedidos");
            Console.WriteLine();
            GetAll();
            Console.ReadKey();
            MenuOrderScreen.Load();
        }

        public static void GetAll()
        {
            using var context = DbContextFactory.CreateDbContext();

            var orders = context.Orders
                .Include(c => c.Customer)
                .Include(o => o.OrderItens)
                    .ThenInclude(p => p.Product)
                .OrderBy(o => o.DateOrder)
                .ToList();

            foreach (var order in orders)
            {
                Console.WriteLine($"ID: {order.Id} - Cliente: {order.Customer.Email} | Total: {order.ValueTotal:C} | Data do pedido: {order.DateOrder:d} | Status: {order.Status}");
                Console.WriteLine();
                Console.WriteLine("Itens do pedido:");

                foreach (var itens in order.OrderItens)
                {
                    Console.WriteLine($@"Produto: {itens.Product.Name} | Preço: {itens.Product.PriceSale:C} | Quantidade {itens.Amount} | Total: {itens.Product.PriceSale * itens.Amount:C}");
                }
                Console.WriteLine("--------------------------------------------");
            }
        }
    }
}