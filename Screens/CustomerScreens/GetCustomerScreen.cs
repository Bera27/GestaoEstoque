using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoque.Screens.CustomerScreens
{
    public class GetCustomerScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Buscar cliente por Email:");
            Console.WriteLine();
            Console.WriteLine("Informe o Email:");
            string email = Console.ReadLine();
            Get(email);
            Console.ReadKey();
            MenuCustomerScreen.Load();
        }

        public static void Get(string email)
        {
            using var context = DbContextFactory.CreateDbContext();

            var customer = context
                .Customers
                .FirstOrDefault(c => c.Email == email);

            if (customer == null)
            {
                Console.WriteLine($"Cliente com o Email '{email}' não existe! verifique e tente de novo.");
                return;
            }

            Console.WriteLine("Cliente encontrado:");
            Console.WriteLine($"ID: {customer.Id} - Nome: {customer.Name} | Email: {customer.Email} | Telefone: {customer.Phone} | Estado: {customer.State} | Cidade: {customer.City} Endereço: {customer.Address} | CEP: {customer.Cep} | Registro: {customer.DateRegistration:d}");
        }
    }
}