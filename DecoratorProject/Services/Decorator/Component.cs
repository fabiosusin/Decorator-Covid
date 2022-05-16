using DecoratorProject.DTO.Services.Covid.Output;
using System.Threading.Tasks;

namespace DecoratorProject.Services.Decorator.Decorator
{
    public abstract class Component
    {
        public abstract Task<CovidSummaryOutput> GetCovidSummaryOutput();
    }
}
