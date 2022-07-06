using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsPet854.Business.Pets;
using LetsPet854.Domain.Common.Enuns;
using LetsPet854.Domain.Pets;

namespace LetsPet854.Business.Attendance
{
    public class Validation
    {
        public static bool CheckAnswer(int answer) //LEMBRAR DE ALOCAR ESTE MÉTODO EM TODAS AS PERGUNTAS!!
        {
            if (Enum.IsDefined(typeof(standardAnswer), answer))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Opção inválida, por favor digite alguma das alternativas.");
                return false;
            }
        }

        public static bool SelectService(int answerService)
        {
            if (Enum.IsDefined(typeof(ServiceType), answerService))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static bool ValidCPF(string cpf)
        {
            string valor = cpf.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
            {
                return false;
            }

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)

                if (valor[i] != valor[0])

                    igual = false;


            if (igual || valor == "12345678909")

                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)

                numeros[i] = int.Parse(valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)

                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {
                if (numeros[9] != 0)

                    return false;
            }

            else if (numeros[9] != 11 - resultado)
                return false;
            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {
                if (numeros[10] != 0)

                    return false;
            }

            else

                if (numeros[10] != 11 - resultado)
            {
                return false;
            }
            return true;

        }


        public static bool CheckPETName(string petName, List<Animal> PetList)
        {
            bool petMatches = PetList.Any(x => x.Name == petName);

            return petMatches;
        }
        public static int ValidateIntIntervalInput(int opcaoMax, string question, string ErrorMessage = "O input é inválido")
        {
            int opcaoMin = 1;
            string response;
            int responseInt;
            bool validation = true;
            do
            {
                Console.WriteLine(question);
                response = Console.ReadLine();
                validation = string.IsNullOrWhiteSpace(response);
                int.TryParse(response, out responseInt);
                if (validation || responseInt < opcaoMin || responseInt > opcaoMax)
                {
                    Console.WriteLine(ErrorMessage);
                    validation = true;
                }
            } while (validation);

            return responseInt;
        }

        public static bool CheckValidDate(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool CheckValidTime(int time)
        {
            if (time < 9 && time > 18)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool HasPetsRegistered(string recuseByNullPetList, Guardian tutor)
        {
            if (tutor.PetList.Count() == 0)
            {
                Console.WriteLine(recuseByNullPetList);
                Console.ReadKey();
                RegisterAnimal.AnimalRegister();
                return false;
            }
            return true;
        }

        public static bool HasMinAge(string recusedByAge, Animal pet)
        {
            if (pet.TwoMonthsBool())
            {
                Console.WriteLine(recusedByAge);
                Console.ReadKey();
                return false;
            }
            return true;
        }
        public static bool CheckPetAgressiveness(string askAgressiveness, string invalidOption, string recuseByAgressiveness, ref Animal pet)
        {
            if (!pet.AggressiveBool)
            {
            VerificarAgressividade:
                int respostaInt;
                string resposta = Business.Common.Validation.ValidateStringInput(askAgressiveness, invalidOption);
                bool ehNum = int.TryParse(resposta, out respostaInt);
                if (!ehNum || !Business.Attendance.Validation.CheckAnswer(respostaInt))
                {
                    Console.WriteLine(invalidOption);
                    goto VerificarAgressividade;
                }
                else if (respostaInt == 1)
                    pet.AggressiveBool = true;
            }
            if (pet.AggressiveBool)
            {
                Console.WriteLine(recuseByAgressiveness);
                Console.ReadKey();
                return false;
            }
            return true;
        }

        public static bool CheckRageVaccine(Animal pet, string vaccine)
        {
            bool VaccineMatch = pet.PetVaccineList.Any(x => x.Equals(vaccine));

            if (VaccineMatch == true)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static bool CheckRecentVaccine (Animal pet, string vaccine, string AskNewVaccine)
        {
            int answer;
            do
            {
                Console.WriteLine(AskNewVaccine);
                int.TryParse(Console.ReadLine(), out answer);
                CheckAnswer(answer);
            } while (CheckAnswer(answer) == false);

            switch (answer)
            {
                case 1:
                    //ADICIONAR MÉTODO E CONFERIR QUESTÃO DE VALIDADE DA VACINA (TEMPO DE DURAÇÃO DA DOSE)!!
                    return true;

                case 2:
                    Console.WriteLine($"O pet não pode ser atendido, pois não contém a vacina de {vaccine} aplicada.");
                    //CHAMAR PARA O MENU PRINCIPAL!
                    return false;

                case 3:
                    //CHAMAR PARA MENU PRINCIPAL
                    return false;

                default:
                    return false;
            }
        }
    }

}


