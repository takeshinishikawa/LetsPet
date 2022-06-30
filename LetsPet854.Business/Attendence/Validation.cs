using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsPet854.Domain.Common.Enuns;
using LetsPet854.Domain.Pets;

namespace LetsPet854.Business.Attendence
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

        public static bool CheckPETName (string petName, List <Animal> PetList)
        {
            bool petMatches = PetList.Any(x => x.Name == petName);

            return petMatches;
        }
    }
}
