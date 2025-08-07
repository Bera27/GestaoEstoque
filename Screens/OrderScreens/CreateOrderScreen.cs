using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Data;
using GestaoEstoque.Models;
using GestaoEstoque.Screens.CustomerScreens;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoque.Screens.OrderScreens
{
    public class CreateOrderScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo Pedido");
            Console.WriteLine("-----------");
            try
            {
                var customer = SelectCustomer();
                if (customer == null)
                    return;

                var order = new Order
                {
                    CustomerId = customer.Id,
                    Status = Models.Enums.OrderStatusEnum.EmAnalise,
                    OrderItens = new List<OrderItens>()
                };

                AddOrderItems(order);
                CalculateTotal(order);
                SaveOrder(order);
                Console.WriteLine("Pedido criado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao criar o pedido!");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            MenuOrderScreen.Load();
        }

        public static void Create(Order order)
        {
            using var context = DbContextFactory.CreateDbContext();

            Console.WriteLine("Informe o ID");
        }

        public static Customer SelectCustomer()
        {
            using var context = DbContextFactory.CreateDbContext();

            Console.WriteLine("Informe o Email do Cliente ou 'NEW' para novo:");
            string option = Console.ReadLine().ToUpper();

            if (option == "NEW")
            {
                CreateCustomerScreen.Load();
                Console.WriteLine("Informe o Email do novo cliente:");
                option = Console.ReadLine();
            }

            return context.Customers.FirstOrDefault(c => c.Email == option);
        }

        public static void AddOrderItems(Order order)
        {
            using var context = DbContextFactory.CreateDbContext();
            var addMore = true;
            var products = context.Products
                .Include(p => p.Stock)
                .AsNoTracking()
                .ToList();

            while (addMore)
            {
                Console.Clear();
                Console.WriteLine("Adicionar Item ao Pedido");
                Console.WriteLine("------------------------");

                foreach (var p in products)
                {
                    Console.WriteLine($"ID: {p.Id} - Produto: {p.Name} | Descrição: {p.Description} | Preço: {p.PriceSale}");
                    Console.WriteLine("--------------------------------------------------------------");
                }

                if (int.TryParse(Console.ReadLine(), out int productId))
                {
                    var product = products.FirstOrDefault(p => p.Id == productId);

                    if (product != null)
                    {
                        Console.WriteLine("Quantidade:");
                        if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                        {
                            if (quantity <= product.Stock.Amount)
                            {
                                order.OrderItens.Add(new OrderItens
                                {
                                    ProductId = product.Id,
                                    Amount = quantity,
                                    PriceUnit = product.PriceSale
                                });

                                product.Stock.Amount -= quantity;
                                context.Update(product);
                                context.SaveChanges();
                            }
                            else
                                Console.WriteLine("Estoque insuficente!");
                        }
                        else
                            Console.WriteLine("Quantidade Inválida!");
                    }
                    else
                        Console.WriteLine("Produto não encontrado!");
                }
                else
                    Console.WriteLine("ID inválido!");

                Console.WriteLine("Adicionar outro item: S/N");
                string option = Console.ReadLine().Substring(0, 1).ToUpper();

                if (option == "N")
                {
                    addMore = false;
                }
            }
        }

        private static void CalculateTotal(Order order)
        {
            order.ValueTotal = order.OrderItens.Sum(item => item.PriceUnit * item.Amount);
        }

        private static void SaveOrder(Order order)
        {
            using var context = DbContextFactory.CreateDbContext();
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}