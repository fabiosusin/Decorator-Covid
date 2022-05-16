using DecoratorProject.DTO.Services.Covid.Output;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DecoratorProject.Services.Covid.Brasil
{
    public class BrasilCovidService
    {
        internal CovidApiService CovidApiService;
        public BrasilCovidService() => CovidApiService = new();

        public async Task<int> GetTotalCases()
        {
            var brazil = await GetBrazilAsync().ConfigureAwait(false);
            return brazil == null ? 0 : brazil.TotalConfirmed;
        }

        public async Task<int> GetTotalDeaths()
        {
            var brazil = await GetBrazilAsync().ConfigureAwait(false);
            return brazil == null ? 0 : brazil.TotalConfirmed;
        }

        public async Task<int> GetTotalNewCases()
        {
            var brazil = await GetBrazilAsync().ConfigureAwait(false);
            return brazil == null ? 0 : brazil.NewConfirmed;
        }

        public async Task<int> GetTotalRecovered()
        {
            var brazil = await GetBrazilAsync().ConfigureAwait(false);
            return brazil == null ? 0 : brazil.TotalRecovered;
        }

        public async Task<int> GetCasesLastDays(int start)
        {
            var brazil = await CovidApiService.GetCasesLastDays("brazil", DateTime.Now.AddDays(-start).ToString("yyyy-MM-dd'T'HH:mm:ss'Z'"), DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'")).ConfigureAwait(false);
            if (!(brazil?.Any() ?? false))
                return 0;

            var first = brazil.FirstOrDefault()?.Cases ?? 0;
            var last = brazil.LastOrDefault()?.Cases ?? 0;
            return last - first;
        }

        private async Task<CountryOutput> GetBrazilAsync() => (await CovidApiService.CovidSummary().ConfigureAwait(false))?.Countries?.FirstOrDefault(x => x.CountryCode == "BR");
    }
}