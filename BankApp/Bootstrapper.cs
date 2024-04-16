using Microsoft.Extensions.DependencyInjection;

namespace BankApp
{
    internal class Bootstrapper
    {
        private readonly IServiceCollection _serviceCollection;

        public Bootstrapper(IServiceCollection serviceCollection)
        {
            this._serviceCollection = serviceCollection ?? new ServiceCollection();
        }

        public IServiceCollection Initialize()
        {
            this._serviceCollection
                .AddEngineConverters()
                .AddProviders()
                .AddServices();

            return this._serviceCollection;
        }
    }
}
