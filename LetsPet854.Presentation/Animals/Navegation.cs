using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsPet854.Business.Pets;
using LetsPet854.Domain.Pets;
using LetsPet854.Presentation.Animals;

namespace LetsPet854.Presentation.Pets
{
    public class Navigation
    {
        public static int optionInput;
        public static void MenuPrincipal()
        {
            do
            {
               Console.WriteLine();
                int.TryParse(Console.ReadLine(), out optionInput);
                switch (optionInput)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Tela para Cadastrar Tutor");
                        GuardianRegister.RegisterGuardian();
                        MenuHeader();
                        return;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Tela para Cadastrar Pet");
                        RegisterAnimal.AnimalRegister();
                        MenuHeader();
                        return;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Tela para Consultar Tutor");
                        Console.WriteLine("Digite um CPF:");
                        var response = Console.ReadLine();
                        var guardianSearchResult = SearchGuardian.SearchGuardianByCPF(response);
                        if (guardianSearchResult == null)
                        {
                            Console.ReadKey();
                        }
                        PrintGuardian.PrintTutor(guardianSearchResult);
                        Console.ReadKey();
                        MenuHeader();
                        return;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Tela para Consultar Pet");
                        Console.WriteLine("Não implementado");
                        //Search.Options(); fazer consulta
                        return;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("voltar ao menu inicial");
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção Inválida");
                        break;
                }
            } while (true);
        }

        private static void MenuHeader()
        {
            Console.Clear();
            Console.WriteLine("------- MENU DE PETS E TUTORES -----------");
            Console.WriteLine(AnimalScrens.MenuPet);
            MenuPrincipal();
        }



    }
}



