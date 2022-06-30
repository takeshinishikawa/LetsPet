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
            if (!Business.Common.Validation.IsCpfValid(resposta) || !Business.Attendance.Validation.ValidCPF(resposta))
            {
                Console.WriteLine(Messages.RecuseByInvalidCPF);
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
            
            int opcaoMax = Messages.OpcaoPet(guardianSearchResult);
            
            int opcao = Business.Attendance.Validation.ValidateIntIntervalInput(opcaoMax, Messages.SelectPetNumber, "Este valor está fora do intervalo listado.");

            Animal pet = Tools.GetPetByName(Tools.SelecionaAnimal(ref guardianSearchResult, opcao), guardianSearchResult.PetList);
            if (pet.TwoMonthsBool())
            {
                Console.WriteLine(Messages.RecuseByAge);
                return;
            }

            PrintAnimal.PrintPet(pet); //apenas para teste, retirar depois
            Console.ReadKey();
            Console.Clear();

        }

    }
}
