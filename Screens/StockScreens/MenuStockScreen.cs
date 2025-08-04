using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEstoque.Screens.StockScreens;

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
            Console.WriteLine();
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CreateProductScreen.Load();
                    break;

                case 2:
                    GetAllProductScreen.Load();
                    break;

                case 3:
                    GetProductScreen.Load();
                    break;

                case 4:
                    UpdateProductScreen.Load();
                    break;

                case 5:
                    DeleteProductScreen.Load();
                    break;
                    
                default: Program.Load(); break;
            }
        }
    }
}