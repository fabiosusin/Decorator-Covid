using DecoratorProject.Services.Covid.Brasil;
using System;
using System.Threading.Tasks;

namespace DecoratorProject.View
{
    public class MainView
    {
        private readonly BrasilCovidService BrasilCovidService;
        public MainView() => BrasilCovidService = new();

        public async Task MainAsync()
        {
            var continueLoop = true;
            do
            {

                Console.WriteLine(await BrasilCovidService.GetCasesLastDays(10).ConfigureAwait(false));
                Console.WriteLine("Escolha uma das ações abaixo: ");
                Console.WriteLine("1) Quantidade total de casos");
                Console.WriteLine("2) Quantidade total de mortes");
                Console.WriteLine("3) Quantidade total de recuperados");
                Console.WriteLine("4) Quantidade total de novos casos");
                Console.WriteLine("5) Quantidade de casos nos ultimos dias");
                Console.WriteLine("9) Sair");

                var actionStr = Console.ReadLine();
                if(!int.TryParse(actionStr, out var action))
                {
                    Console.WriteLine("Ação não encontrada, insira o código corretamente");
                    continue;
                }


            }
            while (continueLoop);
        }

    }
}