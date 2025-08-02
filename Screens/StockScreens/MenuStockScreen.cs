using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEstoque.Screens
{
    public static class MenuStockScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Estoque");
            Console.WriteLine();
            Console.WriteLine("1 - Cadastrar novo produto");
            Console.WriteLine("2 - Listar produtos cadastrados");
            Console.WriteLine("3 - Buscar produto");
            Console.WriteLine("4 - Editar produto");
            Console.WriteLine("5 - Excluir produto");
            Console.WriteLine("6 - Voltar");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                
                default: Program.Load(); break;
            }
        }
    }
}