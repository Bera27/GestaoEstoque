using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Data;

namespace GestaoEstoque.Screens.CustomerScreens
{
    public class UpdateCustomerScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar as informações do Cliente");
            Console.WriteLine();

            Console.WriteLine("Qual o ID:");
            int id = int.Parse(Console.ReadLine());

            Get(id);
            Console.Clear();

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

            Update(id, name, email, phone, address, state, city, cep);
            Console.ReadKey();
            MenuCustomerScreen.Load();
        }

        public static void Get(int id)
        {
            using var context = DbContextFactory.CreateDbContext();

            var customer = context.Customers
                .FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                Console.WriteLine($"Não tem nenhum cliente com esse ID: '{id}'");
                Console.ReadKey();
                MenuCustomerScreen.Load(); 
            }
            Console.WriteLine("");
            Console.WriteLine($"ID: {customer.Id} - Nome: {customer.Name} | Email: {customer.Email} | Telefone: {customer.Phone} | CEP: {customer.Cep}");
            Console.WriteLine("Esse é o cliente desejado? S/N");
            string option = Console.ReadLine().Substring(0, 1).ToUpper();

            if (option == "N")
                return;
        }

        public static void Update(int id, string name, string email, string phone, string address, string state, string city, string cep)
        {
            using var context = DbContextFactory.CreateDbContext();

            try
            {
                var customer = context.Customers
                .FirstOrDefault(c => c.Id == id);

                customer.Name = name;
                customer.Email = email;
                customer.Phone = phone;
                customer.Address = address;
                customer.State = state;
                customer.City = city;
                customer.Cep = cep;
                context.SaveChanges();
                Console.WriteLine("Informações atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel atualizar as informações!");
                Console.WriteLine(ex.Message);
            }

        } 
    }
}