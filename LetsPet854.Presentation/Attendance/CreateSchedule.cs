using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsPet854.Business.Attendance;
using LetsPet854.Business.Attendence;
using LetsPet854.Business.Pets;
using LetsPet854.Domain.Pets;
using LetsPet854.Domain.Services;
using LetsPet854.Presentation.Animals;
using LetsPet854.Presentation.Attendance;


namespace LetsPet854.Presentation.Attendance
{
    public class CreateSchedule
    {
        public static void CreateScheduleMain()
        {
            Console.WriteLine(Messages.AskCPFTutor);
            string tempCPF = Console.ReadLine();
            if (Validation.ValidaCPF(tempCPF) == false)
            {
                Console.WriteLine("CPF inválido.");
                CreateScheduleMain();
            }
            var guardianSearchResult = SearchGuardian.SearchGuardianByCPF(tempCPF);
            if (guardianSearchResult == null)
            {
                Console.WriteLine(Messages.notRegisteredCPFTutor);
                Console.ReadKey();
                GuardianRegister.RegisterGuardian();
                CreateScheduleMain(); //retorna para agendamento após cadastro do tutor
            }
            PrintGuardian.PrintTutor(guardianSearchResult);
            //criar dict
            //solicitar escolha do pet

            Console.WriteLine(Messages.SelectPetName);
            Console.Clear();

        }

    }
}
