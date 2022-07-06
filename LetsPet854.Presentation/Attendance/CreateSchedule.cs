using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsPet854.Business.Attendance;
using LetsPet854.Business.Pets;
using LetsPet854.Domain.Pets;
using LetsPet854.Domain;
using LetsPet854.Presentation.Animals;
using LetsPet854.Presentation.Attendance;
using LetsPet854.Business.Common;
using LetsPet854.Business;
using LetsPet854.Domain.Attendence;

namespace LetsPet854.Presentation.Attendance
{
    public class CreateSchedule
    {
        public static void CreateScheduleMain()
        {
            Console.Clear();
            Console.WriteLine(Messages.HeaderAgendar);
            string cpf = null;
            Guardian tutor = null;
            if (!Tools.GetTutorCPF(Messages.AskCPFTutor, Messages.RecuseByNull, Messages.RecuseByInvalidCPF, ref cpf) || !Tools.GetTutorRegistration(Messages.notRegisteredCPFTutor, cpf, ref tutor) || !Business.Attendance.Validation.HasPetsRegistered(Messages.RecuseByNullPetList, tutor))
                CreateScheduleMain();
            int opcaoMax = Messages.OpcaoPet(tutor);
            int opcao = Business.Attendance.Validation.ValidateIntIntervalInput(opcaoMax, Messages.SelectPetNumber, "Este valor está fora do intervalo listado.");

            Animal pet = Tools.GetPetByName(Tools.SelecionaAnimal(ref tutor, opcao), tutor.PetList);
            if (!Business.Attendance.Validation.HasMinAge(Messages.RecuseByAge, pet) || !Business.Attendance.Validation.CheckPetAgressiveness(Messages.AskAgressiveness, Messages.InvalidOption, Messages.RecuseByAgressiveness, ref pet) || !Business.Attendance.Validation.CheckRageVaccine(pet, "raiva") && !Business.Attendance.Validation.CheckRecentVaccine(pet, "raiva", Messages.AskRecentVaccine))
                return;
            Service service = Tools.ScheduleService(Messages.AskServiceType, Messages.AskCutType, Messages.AskSpecial, Messages.AskLotion, Messages.ServiceNotFound, pet);
            if (service == null)
                return;
            //ShowInfo.ByName(service.Name);//apenas para teste, retirar depois
            string notes = "";
            Tools.AskRemark(Messages.AskRemark, Messages.InformRemark, Messages.RecuseByNull, ref notes);
            Tools.AskAttendantEvaluation(Messages.AskSpecialNeeds, ref service, ref pet);
            if (service == null)
                return;
            //verificar se existe observação, caso positivo, será necessário verificar novamente se é especial se sim, deverá atualizar o serviço
            
            
            //data serviço apenas esboço de caminho feliz aqui, criar validações para erro
            Console.WriteLine(Messages.AskDateScheduling);
            DateTime data = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine(Messages.AskWhatTime);
            TimeOnly time = TimeOnly.Parse(Console.ReadLine());
            Business.Attendance.Validation.CheckValidDate(data);
            //buscar lista de empregados aqueles que se encaixam nas especificações do serviço
            //Buscar na EmployeeAgendaRegister.EmployeesListAgenda a agenda do funcionário para a data (caso não exista, deverá ser adicionado)
            //caso exista, deverá constar como 'F' durante o período de duração do serviço
            //DailyAgenda temp;
            //agenda.Agenda.TryGetValue(DateOnly.FromDateTime(day), out temp);//verifica se já existe agenda do determinado dia criado

            ShowInfo.ByName(service.Name);//apenas para teste, retirar depois
            PrintAnimal.PrintPet(pet); //apenas para teste, retirar depois
            Console.ReadKey();
            Console.Clear();

        }

    }
}
