using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /*public static int ValidateIntInput(int opcaoMax, string question, string ErrorMessage = "O input é inválido")
        {
            string response;
            bool validation;
            do
            {
                Console.WriteLine(question);
                response = Console.ReadLine();
                validation = string.IsNullOrWhiteSpace(response);

                if (validation)
                {
                    Console.WriteLine(ErrorMessage);
                }
            } while (validation);

            return response;
        }*/

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
    }

}


