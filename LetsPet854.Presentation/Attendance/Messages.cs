using LetsPet854.Domain.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsPet854.Presentation.Attendance
{
    public static class Messages
    {
        public const string MainMenu = @"
========== AGENDAMENTO ==========

1 - Agendar atendimento
2 - Consultar agenda
3 - Relatório de caixa
4 - Retornar ao menu anterior";

        public const string InvalidOption = @"Opção inválida!
Digite novamente.";

        public const string RecuseByAge = @"O atendimento não poderá ser realizado, pois o pet não atingiu a idade mínima (2 meses).";

        public const string RecuseByInvalidRageVaccine = @"O atendimento não poderá ser realizado, pois o pet não está com a vacina de raiva em dia.";

        public const string RecuseByAgressiveness = @"O atendimento não poderá ser realizado, pois o pet foi inicialmente identificado como agressivo.";

        public const string AskCPFTutor = @"Por favor, digite o CPF do tutor.";
        public const string notRegisteredCPFTutor = @"O CPF não está em nossa base de cadastro. Você será redirecionado para o cadastro de Tutor.";
        public static int OpcaoPet(Guardian guardian)
        {
            int opcao = 1;
            foreach (var item in guardian.PetList)
            {
                Console.WriteLine($"{opcao} - {item.Name}");
                opcao++;
            }
            return opcao;
        }
        public const string SelectPetName = @"
O atendimento será para qual pet?
Digite o nome do pet:";
        public const string SelectPetNumber = @"
O atendimento será para qual pet?
Digite o número do pet:";

        public const string AskRecentVaccine = @"
No nosso sistema consta que a vacina de raiva do seu pet está vencida..
Seu pet tomou alguma vacina recentemente? Digite:
1 - Sim
2 - Não
3 - Sair";

        // incluir a opção "sair" no método de verificação de serviços
        public const string AskServiceType = @"
Qual o serviço desejado? Digite:
1 - Banho
2 - Tosa
3 - Sair";

        public const string AskRemark = @"
Gostaria de deixar alguma observação? 
(Ex: o pet está no cio, o pet está com a pata machucada, etc.)";

        public const string AskSpecialNeeds = @"
De acordo com a observação do tutor, pode-se considerar que o pet possui alguma necessidade especial?
Digite:
1 - Sim
2 - Não
3 - Sair";

        public const string AskDateScheduling = @"Em qual data gostaria de realizar o agendamento? (dd/mm/aaaa)";

        public const string AskWhatTime = @"Em qual horário?";

        public const string AskAnotherDateTime = @"
Poxa, infelizmente esse horário não está disponível :(
Gostaria de escolher algum outro? Digite:
1 - Sim
2 - Não
3 - Sair";

        public const string AskSelectAttendant = @"O tutor gostaria de selecionar o profissional que irá realizar o atendimento? Digite:
1 - Sim
2 - Não
3 - Sair";

        public const string AskAttendantOpinion = @"Houve algum incidente durante o atendimento? Digite:
1 - Sim
2 - Não
3 - Sair";

        public const string AskIncidentType = @"Descreva, em poucas palavras, o incidente ocorrido.";

        public const string AskIncidentLevel = @"Qual foi o nível do incidente? Digite:
1 - Leve
2 - Médio
3 - Grave";

        public const string AskAgressivenessDuringService = @"O pet apresentou comportamento agressivo durante o serviço? Digite:
1 - Sim
2 - Não
3 - Sair";

        public const string AskServiceStatus = @"O atendimento já foi concluido? Digite:
1 - Sim
2 - Não
3 - Sair";

        //Validar quais os tipos de necessidades especiais o pet poderia ter durante o serviço apenas para exemplificar na msg
        public const string AskSpecialNeedsDuringService = @"Pode-se dizer que o pet precisou de cuidados especiais durante o serviço? Digite:
1 - Sim
2 - Não
3 - Sair";


    }
}
