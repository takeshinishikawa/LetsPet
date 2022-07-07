using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsPet854.Business.Attendance;
using LetsPet854.Business.Common;
using LetsPet854.Domain.Attendence;

namespace LetsPet854.Presentation.Attendance
{
    public class RegisterAttendance
    {
        public void RegisterAttendanceMain(Schedule schedule)
        {
            Console.Clear();

            var option = Business.Attendance.Validation.ValidateIntIntervalInput(3, Messages.AskAttendantOpinion);

            switch (option)
            {
                case 1:
                    var incidentNote = Business.Common.Validation.ValidateStringInput(Messages.AskIncidentType);
                    Tools.SetIncidentNotes(incidentNote, schedule);
                    break;
                case 2:
                    //seguir com o fluxo
                    break;
                case 3:
                    //retornar ao menu anterior
                    break;
            }
            
            option = Business.Attendance.Validation.ValidateIntIntervalInput(3, Messages.AskIncidentLevel);

            switch (option)
            {
                case 1:
                    schedule.IncidentLevel = Domain.Common.Enuns.IncidentLevel.Leve;
                    break;
                case 2:
                    schedule.IncidentLevel = Domain.Common.Enuns.IncidentLevel.Médio;
                    break;
                case 3:
                    schedule.IncidentLevel = Domain.Common.Enuns.IncidentLevel.Grave;
                    break;
            }

            option = Business.Attendance.Validation.ValidateIntIntervalInput(3, Messages.AskAgressivenessDuringService);

            switch (option)
            {
                case 1:
                    schedule.Pet.AggressiveBool = true;
                    break;
                case 2:
                    schedule.Pet.AggressiveBool = false;
                    break;
                case 3:
                    //retornar ao menu anterior
                    break;
            }

            /*
            option = Business.Attendance.Validation.ValidateIntIntervalInput(3, Messages.AskServiceStatus);

            //verificar status de atendimento (finalizado ou em andamento)
            switch (option)
            {
                case 1:

                    break;
            }
            */

            option = Business.Attendance.Validation.ValidateIntIntervalInput(3, Messages.AskSpecialNeedsDuringService);

            switch (option)
            {
                case 1:
                    schedule.TempSpecialNeeds = true;
                    Tools.GetServicePrice(schedule);
                    break;
                case 2:
                    Tools.GetServicePrice(schedule);
                    break;
            }

            option = Business.Attendance.Validation.ValidateIntIntervalInput(3, Messages.PaymentMethod);

            switch (option)
            {
                case 1:
                    schedule.PaymentMethod = Domain.Common.Enuns.PaymentMethod.Dinheiro;
                    break;
                case 2:
                    schedule.PaymentMethod = Domain.Common.Enuns.PaymentMethod.PIX;
                    break;
                case 3:
                    schedule.PaymentMethod = Domain.Common.Enuns.PaymentMethod.Cartão;
                    break;
            }

            schedule.departureDateTimeReal = DateTime.Now;

        }
    }
}
