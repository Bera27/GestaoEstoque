using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                
                default: Program.Load(); break;
            }
        }
    }
}