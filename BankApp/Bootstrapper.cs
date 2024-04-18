using Microsoft.Extensions.DependencyInjection;

namespace BankApp
{
    internal class Bootstrapper
    {
        private readonly IServiceCollection serviceCollection;

        public Bootstrapper(IServiceCollection serviceCollection)
        {
            this.serviceCollection = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));
        }

        public IServiceCollection Initialize()
        {
            this.serviceCollection
                .AddEngineConverters()
                .AddProviders()
                .AddServices();

            return this.serviceCollection;
        }
    }
}
