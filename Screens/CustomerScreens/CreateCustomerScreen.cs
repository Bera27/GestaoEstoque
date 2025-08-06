using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Data;
using GestaoEstoque.Models;

namespace GestaoEstoque.Screens.CustomerScreens
{
    public static class CreateCustomerScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de novo Cliente");
            Console.WriteLine();
            Console.WriteLine("Nome:");
            string name = Console.ReadLine();

            Console.WriteLine("Email:");
            string email = Console.ReadLine();

            Console.WriteLine("Telefone:");
            string phone = Console.ReadLine();

            Console.WriteLine("Endereço:");
            string address = Console.ReadLine();

            Console.WriteLine("Estado:");
            string state = Console.ReadLine();

            Console.WriteLine("Cidade:");
            string city = Console.ReadLine();

            Console.WriteLine("CEP:");
            string cep = Console.ReadLine();

            Create(new Customer
            {
                Name = name,
                Email = email,
                Phone = phone,
                Address = address,
                State = state,
                City = city,
                Cep = cep
            });
            Console.ReadKey();
            MenuCustomerScreen.Load();
        }

        public static void Create(Customer customer)
        {
            using var context = DbContextFactory.CreateDbContext();
            try
            {
                context.Add(customer);
                context.SaveChanges();
                Console.WriteLine("Cadastro realizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel Cadastrar!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}