using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Data;

namespace GestaoEstoque.Screens.CustomerScreens
{
    public class DeleteCustomerScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir Dados de cliete");
            Console.WriteLine();
            Console.WriteLine("Qual o ID:");
            int id = int.Parse(Console.ReadLine());
            Delete(id);
            Console.ReadKey();
            MenuCustomerScreen.Load();
        }

        public static void Delete(int id)
        {
            using var context = DbContextFactory.CreateDbContext();

            try
            {
                var customer = context.Customers.FirstOrDefault(c => c.Id == id);
                context.Remove(customer);
                context.SaveChanges();
                Console.WriteLine("Dados do cliente excluido com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel excluir!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}