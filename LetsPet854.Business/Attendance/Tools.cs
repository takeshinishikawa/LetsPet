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
        public static Animal GetPetByName(string petName, List<Animal> PetList)
        {
            Animal petMatches = PetList.Find(x => x.Name == petName);

            return petMatches;
        }
    }
}
