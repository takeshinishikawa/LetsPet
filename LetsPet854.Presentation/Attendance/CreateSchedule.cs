using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsPet854.Business.Attendance;
using LetsPet854.Business.Pets;
using LetsPet854.Domain.Pets;
using LetsPet854.Domain.Services;
using LetsPet854.Presentation.Animals;
using LetsPet854.Presentation.Attendance;
using LetsPet854.Business.Common;


namespace LetsPet854.Presentation.Attendance
{
    public class CreateSchedule
    {
        public static void CreateScheduleMain()
        {
            Console.WriteLine(Messages.HeaderAgendar);
            string resposta = Business.Common.Validation.ValidateStringInput(Messages.AskCPFTutor, Messages.RecuseByNull);
            if (Business.Attendance.Validation.ValidCPF(resposta) == false)
            {
                Console.WriteLine("CPF inválido.");
                CreateScheduleMain();
            }
            var guardianSearchResult = SearchGuardian.SearchGuardianByCPF(resposta);
            if (guardianSearchResult == null)
            {
                Console.WriteLine(Messages.notRegisteredCPFTutor);
                Console.ReadKey();
                GuardianRegister.RegisterGuardian();
                CreateScheduleMain(); //retorna para agendamento após cadastro do tutor
            }
            string tempCPF = resposta;
            //verificar quantidade de animais
            if (guardianSearchResult.PetList.Count() < 0)
            {
                Console.WriteLine(Messages.RecuseByNullPetList);
                RegisterAnimal.AnimalRegister();
            }
            //PrintGuardian.PrintTutor(guardianSearchResult);
            int opcaoMax = Messages.OpcaoPet(guardianSearchResult);
            //criar dict
            //solicitar escolha do pet
            Business.Attendance.Validations.ValidateIntInput(opcaoMax, Messages.SelectPetNumber, "Este valor está fora do intervalo listado.")
            //Console.WriteLine(Messages.SelectPetName);
            Console.WriteLine(Messages.SelectPetNumber);
            resposta = Console.ReadLine();
            
            int opcao;
            int.TryParse(resposta, out opcao);


            Animal pet = Tools.GetPetByName(Tools.SelecionaAnimal(ref guardianSearchResult, opcao), guardianSearchResult.PetList);

            Console.WriteLine("DEU CERTO!");
            PrintAnimal.PrintPet(pet);
            Console.ReadKey();
            Console.Clear();

        }

    }
}
