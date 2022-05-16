using DecoratorProject.DTO.Services.Covid.Output;
using System.Threading.Tasks;

namespace DecoratorProject.Services.Decorator.Decorator
{
    public abstract class Decorator : Component
    {
        protected Component Component;
        public Decorator(Component component) => Component = component;
        public override async Task<CovidSummaryOutput> GetCovidSummaryOutput() => await Component.GetCovidSummaryOutput();
    }
}
