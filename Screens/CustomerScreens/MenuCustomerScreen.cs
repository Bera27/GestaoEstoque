using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Screens.CustomerScreens;

namespace GestaoEstoque.Screens
{
    public static class MenuCustomerScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Clientes");
            Console.WriteLine();
            Console.WriteLine("1 - Cadastrar novo cliente");
            Console.WriteLine("2 - Buscar cliente");
            Console.WriteLine("3 - Listar clientes");
            Console.WriteLine("4 - Editar cliente");
            Console.WriteLine("5 - Excluir dados de cliente");
            Console.WriteLine("6 - Voltar");
            Console.WriteLine();
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CreateCustomerScreen.Load();
                    break;

                case 2:
                    GetCustomerScreen.Load();
                    break;

                case 3:
                    GetAllCustomerScreen.Load();
                    break;

                case 4:
                    UpdateCustomerScreen.Load();
                    break;
                
                case 5:
                    DeleteCustomerScreen.Load();
                    break;
                
                default: Program.Load(); break;
            }
        }
    }
}