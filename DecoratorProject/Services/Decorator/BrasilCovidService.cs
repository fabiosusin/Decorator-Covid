using DecoratorProject.DTO.Services.Covid.Output;
using DecoratorProject.Services.Covid;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DecoratorProject.Services.Decorator.Decorator
{
    public class BrasilCovidService : Decorator
    {
        internal CovidApiService CovidApiService;
        public BrasilCovidService(Component component) : base(component) => CovidApiService = new();

        public override async Task<CovidSummaryOutput> GetCovidSummaryOutput()
        {
            var result = await base.GetCovidSummaryOutput();
            if (result == null)
                return null;

            result.Result = new(result?.Countries?.FirstOrDefault(x => x.CountryCode == "BR"));
            return result;
        }
    }
}