using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Data;
using GestaoEstoque.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoque.Screens.OrderScreens
{
    public class UpdateStatusOrderScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar o Status do pedido");
            Console.WriteLine();
            Console.WriteLine("Informe o ID:");
            int id = int.Parse(Console.ReadLine());

            Console.Clear();
            Update(id);
            Console.ReadKey();
            MenuOrderScreen.Load();
        }

        public static void Update(int id)
        {
            using var conntext = DbContextFactory.CreateDbContext();
            var order = conntext.Orders
                .Include(c => c.Customer)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                Console.WriteLine($"Não existe um pedido com esse ID: {id}");
                return;
            }

            Console.WriteLine($"Status Atual do pedido de: {order.Customer.Email} é ({order.Status})");
            Console.WriteLine();
            Console.WriteLine("Deseja mudar para qual opção abaixo:");
            Console.WriteLine("1 - Em Processamento");
            Console.WriteLine("2 - Enviado");
            Console.WriteLine("3 - Entregue");
            Console.WriteLine("4 - Cancelado | Isso irá apagar o pedido da base de dados");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    order.Status = Models.Enums.OrderStatusEnum.EmProcessamento;
                    break;

                case 2:
                    order.Status = Models.Enums.OrderStatusEnum.Enviado;
                    break;

                case 3:
                    order.Status = Models.Enums.OrderStatusEnum.Entregue;
                    break;

                case 4:
                    Delete(order);
                    break;

                default:
                    MenuOrderScreen.Load();
                    break;
            }
            conntext.Update(order);
            conntext.SaveChanges();
            Console.Clear();
            Console.WriteLine("Status Atualizado!");
            Console.WriteLine($"Status Atual do pedido de: {order.Customer.Email} é ({order.Status})");
        }

        public static void Delete(Order order)
        {
            using var conntext = DbContextFactory.CreateDbContext();

            try
            {
                conntext.Remove(order);
                Console.WriteLine("Pedido Cancelado com sucesso");
                Console.ReadKey();
                MenuOrderScreen.Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel Cancelar o pedido");
                Console.WriteLine(ex.Message);
            }
        }
    }
}