using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsPet854.Business.Attendance;

namespace LetsPet854.Presentation.Attendance
{
    public class MenuAttendance
    {
        public static void MainMenu()
        {
            var inputValido = false;
            var opcaoEscolhida = 0;

            Console.Clear();
            Console.WriteLine(Messages.MainMenu);

            while (!inputValido)
            {
                inputValido = (int.TryParse(Console.ReadLine(), out opcaoEscolhida) && opcaoEscolhida > 0 && opcaoEscolhida <= 4);

                if (inputValido)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(Messages.InvalidOption);
                }
            }

            switch (opcaoEscolhida)
            {
                case 1:
                    CreateSchedule.CreateScheduleMain();
                    break;
                case 2:
                    SearchSchedule.SearchSchedulings();
                    break;
                case 3:
                    Reports.CashReport();
                    break;
                case 4:
                    //Chamar método do menu principal
                    break;
            }


        }
    }
}
