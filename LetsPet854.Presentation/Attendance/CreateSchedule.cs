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

namespace LetsPet854.Presentation.Attendance
{
    public class CreateSchedule
    {
        public static void CreateScheduleMain()
        {
            Console.Clear();
            Console.WriteLine(Messages.HeaderAgendar);
            /*string resposta = Business.Common.Validation.ValidateStringInput(Messages.AskCPFTutor, Messages.RecuseByNull);
            if (!Business.Common.Validation.IsCpfValid(resposta) || !Business.Attendance.Validation.ValidCPF(resposta))
            {
                Console.WriteLine(Messages.RecuseByInvalidCPF);
                CreateScheduleMain();
            }*/
            string cpf = null;
            Guardian tutor = null;
            if (!Tools.GetTutorCPF(Messages.AskCPFTutor, Messages.RecuseByNull, Messages.RecuseByInvalidCPF, ref cpf) || !Tools.GetTutorRegistration(Messages.notRegisteredCPFTutor, cpf, ref tutor) || !Business.Attendance.Validation.HasPetsRegistered(Messages.RecuseByNullPetList, tutor))
                CreateScheduleMain();

            /*var guardianSearchResult = SearchGuardian.SearchGuardianByCPF(resposta);
            if (guardianSearchResult == null)
            {
                Console.WriteLine(Messages.notRegisteredCPFTutor);
                Console.ReadKey();
                GuardianRegister.RegisterGuardian();
                CreateScheduleMain(); //retorna para agendamento após cadastro do tutor
            }*/


            //verificar quantidade de animais
            /*if (tutor.PetList.Count() == 0)
            {
                Console.WriteLine(Messages.RecuseByNullPetList);
                Console.ReadKey();
                RegisterAnimal.AnimalRegister();
            }*/

            int opcaoMax = Messages.OpcaoPet(tutor);
            int opcao = Business.Attendance.Validation.ValidateIntIntervalInput(opcaoMax, Messages.SelectPetNumber, "Este valor está fora do intervalo listado.");

            Animal pet = Tools.GetPetByName(Tools.SelecionaAnimal(ref tutor, opcao), tutor.PetList);
            if (!Business.Attendance.Validation.HasMinAge(Messages.RecuseByAge, pet) || !Business.Attendance.Validation.CheckPetAgressiveness(Messages.AskAgressiveness, Messages.InvalidOption, Messages.RecuseByAgressiveness, ref pet))
                return;

            /*if (pet.TwoMonthsBool())
            {
                Console.WriteLine(Messages.RecuseByAge);
                Console.ReadKey();
                return;
            }*/
            //INCLUIR AQUI VALIDAÇÃO DE VACINAS <-----------------------------------------------------

            //isAgressive() <- verificar para atualizar agressividade
            /*if (!pet.AggressiveBool)
            {
                VerificarAgressividade:
                int respostaInt;
                string resposta = Business.Common.Validation.ValidateStringInput(Messages.AskAgressiveness, Messages.InvalidOption);
                bool ehNum = int.TryParse(resposta, out respostaInt);
                if (!ehNum || !Business.Attendance.Validation.CheckAnswer(respostaInt))
                {
                    Console.WriteLine(Messages.InvalidOption);
                    goto VerificarAgressividade;
                }
                else if (respostaInt == 1)
                    pet.AggressiveBool = true;
            }
            if (pet.AggressiveBool)
            {
                Console.WriteLine(Messages.RecuseByAgressiveness);
                Console.ReadKey();
                return;
            }*/


            //método para buscar todos os dados faltantes do agendamento

            // -->SCHEDULESERVICE
            //--> ASK_REMARK se service.Special for true

            //int opcaoMax = Messages.OpcaoPet(guardianSearchResult);
            //int opcao = Business.Attendance.Validation.ValidateIntIntervalInput(opcaoMax, Messages.SelectPetNumber, "Este valor está fora do intervalo listado.");

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


            ShowInfo.ByName(service.Name);//apenas para teste, retirar depois
            PrintAnimal.PrintPet(pet); //apenas para teste, retirar depois
            Console.ReadKey();
            Console.Clear();

        }

    }
}
