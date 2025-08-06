using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoque.Screens.CustomerScreens
{
    public class GetAllCustomerScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Clientes");
            Console.WriteLine();
            GetAll();
            Console.ReadLine();
            MenuCustomerScreen.Load();
        }

        public static void GetAll()
        {
            using var context = DbContextFactory.CreateDbContext();

            var customer = context.Customers
                .AsNoTracking()
                .ToList();

            foreach (var c in customer)
            {
                Console.WriteLine($"ID: {c.Id} - Nome: {c.Name} | Email: {c.Email} | Telefone: {c.Phone} | Estado: {c.State} | Cidade: {c.City} Endereço: {c.Address} | CEP: {c.Cep} | Registro: {c.DateRegistration:d}");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------");
            }
        }
    }
}