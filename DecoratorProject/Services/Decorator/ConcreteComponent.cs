using DecoratorProject.DTO.Services.Covid.Output;
using DecoratorProject.Services.Covid;
using System;
using System.Threading.Tasks;

namespace DecoratorProject.Services.Decorator.Decorator
{
    public class ConcreteComponent : Component
    {
        internal CovidApiService CovidApiService;
        public ConcreteComponent() => CovidApiService = new();

        public override async Task<CovidSummaryOutput> GetCovidSummaryOutput()
        {
            var result = await CovidApiService.CovidSummary();
            if (result == null)
                return null;

            result.Result = new(result.Global);
            return result;
        }
    }
}
