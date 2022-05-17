using DecoratorProject.DTO.View.Enum;
using DecoratorProject.Services.Covid;
using DecoratorProject.Services.Decorator.Decorator;
using System;
using System.Threading.Tasks;

namespace DecoratorProject
{
    public class Program
    {
        static async Task Main()
        {
            _ = await new CovidApiService().CovidSummary();
            var component = new ConcreteComponent();
            var brazilService = new BrasilCovidService(component);
            var summary = await brazilService.GetCovidSummaryOutput();
            if (summary.Result == null)
            {
                Console.WriteLine("Não foi possível buscar os dados do Serviço!");
                return;
            }

            var continueLoop = true;
            do
            {
                Console.WriteLine("Escolha uma das ações abaixo: ");
                Console.WriteLine("1) Quantidade total de casos");
                Console.WriteLine("2) Quantidade total de mortes");
                Console.WriteLine("3) Quantidade total de recuperados");
                Console.WriteLine("4) Quantidade total de novos casos");
                Console.WriteLine("5) Quantidade total de novas mortes");
                Console.WriteLine("9) Sair");

                var actionStr = Console.ReadLine();
                Console.WriteLine();
                if (!int.TryParse(actionStr, out var action))
                    Console.WriteLine("Ação não encontrada, insira o código corretamente");
                else
                    switch ((ViewActionEnum)action)
                    {
                        case ViewActionEnum.TotalCases:
                            Console.WriteLine($"Total de Casos: {summary.Result.TotalConfirmed}");
                            break;
                        case ViewActionEnum.TotalDeaths:
                            Console.WriteLine($"Total de Mortes: {summary.Result.TotalDeaths}");
                            break;
                        case ViewActionEnum.TotalRecovereds:
                            Console.WriteLine($"Total de Recuperados: {summary.Result.TotalRecovered}");
                            break;
                        case ViewActionEnum.TotalNewCases:
                            Console.WriteLine($"Total de Novos Casos: {summary.Result.NewConfirmed}");
                            break;
                        case ViewActionEnum.TotalNewDeaths:
                            Console.WriteLine($"Total de Novas Mortes: {summary.Result.NewDeaths}");
                            break;
                        case ViewActionEnum.Close:
                            continueLoop = false;
                            break;
                        default:
                            Console.WriteLine("Ação não encontrada!");
                            break;
                    }

                Console.WriteLine("Pressione Qualquer Tecla para Continuar...");
                Console.ReadKey();
                Console.Clear();
            }
            while (continueLoop);
        }
    }
}
