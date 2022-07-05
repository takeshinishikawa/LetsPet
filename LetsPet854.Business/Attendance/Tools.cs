using LetsPet854.Business.Pets;
using LetsPet854.Domain;
using LetsPet854.Domain.Common.Enuns;
using LetsPet854.Domain.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPet854.Business.Attendance
{
    public class Tools
    {
        public static void StdString(ref string input)
        {
            input = input.Trim();
            input = input.Replace(".", "").Replace("-", "");
        }
        public static string SelecionaAnimal(ref Guardian guardian, int opcao)
        {
            int contador = 1;
            foreach (Animal item in guardian.PetList)
            {
                if (contador == opcao)
                    return item.Name;
                contador++;
            }
            return "";
        }
        public static bool GetTutorCPF(string askCPFTutor, string recuseByNull, string recuseByInvalidCPF, ref string cpf)
        {
            cpf = Business.Common.Validation.ValidateStringInput(askCPFTutor, recuseByNull);
            if (!Business.Common.Validation.IsCpfValid(cpf) || !Business.Attendance.Validation.ValidCPF(cpf))
            {
                Console.WriteLine(recuseByInvalidCPF);
                return false;
            }
            return true;
        }

        public static bool GetTutorRegistration(string notRegisteredTutor, string cpf, ref Guardian tutor)
        {
            tutor = SearchGuardian.SearchGuardianByCPF(cpf);
            if (tutor == null)
            {
                Console.WriteLine(notRegisteredTutor);
                Console.ReadKey();
                GuardianRegister.RegisterGuardian();
                return false; //retorna para agendamento após cadastro do tutor
            }
            return true;
        }
        public static Animal GetPetByName(string petName, List<Animal> PetList)
        {
            Animal petMatches = PetList.Find(x => x.Name == petName);

            return petMatches;
        }

        public static Service ScheduleService(string tipoServico, string tipoTosa, string especial, string locao, string servicoNaoEncontrado, Animal pet)
        {
            Service newService = new();
            Console.WriteLine(tipoServico);
            PrintEnum.ServiceType();
            newService.Type = Enum.GetName(typeof(ServiceType), Validations.Options(1, 2));

            if (newService.Type == "Tosa")
            {
                Console.WriteLine(tipoTosa);
                PrintEnum.GroomingType();
                newService.GroomingType = Enum.GetName(typeof(GroomingType), Validations.Options(1, 3));
            }
            else
                newService.GroomingType = null;

            newService.Species = pet.Species.ToString();
            newService.Size = pet.BreedSize.ToString();
            newService.Employees = (newService.Size == "Grande") ? 2 : 1;
            Console.WriteLine(especial);
            newService.Special = Validations.YesOrNo();
            Console.WriteLine(locao);
            newService.Lotion = Validations.YesOrNo();

            Service catalogedService = SearchServiceBySchedule(pet, newService);
            if (catalogedService == null)
            {
                Console.WriteLine(servicoNaoEncontrado);
                return catalogedService;
            }
            /*Console.WriteLine("Qual o nome deste serviço?");
            newService.Name = Validations.ExistentName();*/
            //criar um lógica de busca do NOME para o serviço com estas características dentro de Registration.ServicesList
            newService.Name = catalogedService.Name;

            /*Console.WriteLine("Qual o valor deste serviço?");
            newService.Price = Validations.ValidDouble();*/
            //criar um lógica de busca do PRECO para o serviço com estas características dentro de Registration.ServicesList
            newService.ServiceTime = catalogedService.ServiceTime;
            newService.Price = catalogedService.Price;
            //Console.WriteLine("Cadastro Realizado!\n");

            //ShowInfo.ByName(newService.Name);
            return newService;
        }
        public static Service SearchServiceBySchedule(Animal pet, Service newService)
        {
            if (newService.Type == "Banho")
            {
                var FilteredService = (
                from service in Registration.ServicesList
                where service.Type.Equals(newService.Type)
                //&& service.GroomingType.Equals(newService.GroomingType)
                && service.Species.Equals(pet.Species.ToString())
                && service.Size.Equals(pet.BreedSize.ToString())
                && service.Employees.Equals(newService.Employees)
                && service.Special.Equals(newService.Special)
                && service.Lotion.Equals(newService.Lotion)
                select service
                );
                if (FilteredService.Count() == 0)
                {
                    Console.WriteLine($"Nenhum serviço com as características listadas foi encontrado no sistema.");
                    return null;
                }
                return FilteredService.First();
            }
            else
            {
                var FilteredService = (
                    from service in Registration.ServicesList
                    where service.Type.Equals(newService.Type)
                    && service.GroomingType.Equals(newService.GroomingType)
                    && service.Species.Equals(pet.Species.ToString())
                    && service.Size.Equals(pet.BreedSize.ToString())
                    && service.Employees.Equals(newService.Employees)
                    && service.Special.Equals(newService.Special)
                    && service.Lotion.Equals(newService.Lotion)
                    select service
                    );
                if (FilteredService.Count() == 0)
                {
                    Console.WriteLine($"Nenhum serviço com as características listadas foi encontrado no sistema.");
                    return null;
                }
                return FilteredService.First();
            }
        }
        public static bool basicCheck(string message)
        {
            Console.WriteLine(message);
            return Validations.YesOrNo();
        }
        public static void AskRemark(string askRemark, string informRemark, string recuseByNull, ref string notes)
        {
            if (Tools.basicCheck(askRemark))
                Tools.GetRemark(informRemark, recuseByNull, ref notes);
        }
        private static void GetRemark(string informRemark, string recuseByNull, ref string notes)
        {
            notes = Common.Validation.ValidateStringInput(informRemark, recuseByNull);
        }
        public static void AskAttendantEvaluation(string askSpecialNeeds, ref Service service, ref Animal pet)
        {
            if (!service.Special)
            {
                service.Special = Tools.basicCheck(askSpecialNeeds);
                if (service.Special)
                    service = Tools.SearchServiceBySchedule(pet, service);
            }
        }

    }
}
