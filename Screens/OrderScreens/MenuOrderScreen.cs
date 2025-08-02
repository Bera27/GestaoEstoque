using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            Console.WriteLine("2 - Buscar um Pedido por ID");
            Console.WriteLine("3 - Atualizar Status do pedido");
            Console.WriteLine("4 - Cancelar um pedido");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                
                default: Program.Load(); break;
            }
        }
    }
}