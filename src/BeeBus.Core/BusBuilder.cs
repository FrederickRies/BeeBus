using Microsoft.Extensions.DependencyInjection;

namespace BeeBus.Core
{
    public class BusBuilder
    {
        private readonly IServiceCollection _services;

        public BusBuilder(IServiceCollection services)
        {
            _services = services;
        }
    }
}
