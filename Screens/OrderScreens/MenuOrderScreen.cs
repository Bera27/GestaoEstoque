using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Screens.OrderScreens;

namespace GestaoEstoque.Screens
{
    public static class MenuOrderScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Pedidos");
            Console.WriteLine();
            Console.WriteLine("1 - Fazer um pedido");
            Console.WriteLine("2 - Listar todos pedidos");
            Console.WriteLine("3 - Buscar um Pedido por ID");
            Console.WriteLine("4 - Atualizar Status do pedido");
            Console.WriteLine("5 - Voltar");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CreateOrderScreen.Load();
                    break;

                case 2:
                    GetAllOrderScreen.Load();
                    break;

                case 3:
                    GetOrderScreen.Load();
                    break;
                
                case 4:
                    UpdateStatusOrderScreen.Load();
                    break;
                    
                default: Program.Load(); break;
            }
        }
    }
}