using LetsPet854.Domain.Pets;
using LetsPet854.Domain.Services;
using LetsPet854.Presentation.Animals;
using LetsPet854.Presentation.Pets;

namespace LetsPet854.Presentation
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
            MenuInicial:
                Console.Clear();
                Console.WriteLine("Bem vindo ao Let's Pet");
                Console.WriteLine("Qual menu voc� deseja acessar?");
                Console.WriteLine("1 - Pets e Tutores \n2 - Servi�os\n3 - Funcion�rios\n4 - Atendimentos\n5 - Produtos\n6 - Sair");

                switch (Validations.Options(1, 5))
                {
                    case 1:
                        Console.WriteLine(AnimalScrens.MenuPet);
                        Navigation.MenuPrincipal();
                        goto MenuInicial;
                    case 2:
                        ServicesMain.DefaultMenu();
                        goto MenuInicial;
                    case 3:
                        MenuEmployee.DefaultMenu();
                        goto MenuInicial;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        goto MenuInicial;
                }
            }
            EndProgram();
        }

        public static void EndProgram()
        {
            Console.WriteLine($"Deseja realizar outra opera��o?\n1 - Sim\n2 - N�o");
            if (Validations.Options(1, 2) == 1)
                Main();
            else
                Console.WriteLine("Programa encerrado.");
        }
    }
}