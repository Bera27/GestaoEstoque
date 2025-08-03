
using GestaoEstoque.Screens;

namespace GestaoEstoque
{
    class Program
    {
        static void Main(String[] args)
        {
            Load();
        }

        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Bem Vindo!");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de Estoque");
            Console.WriteLine("2 - Gestão de Clientes");
            Console.WriteLine("3 - Gestão de Pedidos");
            Console.WriteLine("4 - Relatórios");
            Console.WriteLine("5 - Sair");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    MenuStockScreen.Load();
                    break;

                case 2:
                    MenuCustomerScreen.Load();
                    break;

                case 3:
                    MenuOrderScreen.Load();
                    break;
                
                default: Load(); break;
            }
            
        }
    }
}