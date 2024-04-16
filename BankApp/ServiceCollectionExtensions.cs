using BankApp.Business.Converters;
using BankApp.Business.Provider;
using BankApp.Business.Services;


using Microsoft.Extensions.DependencyInjection;

namespace BankApp
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEngineConverters(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<IConverter<long, byte[]>, HOTPConverter>();

            return serviceCollection;
        }

        public static IServiceCollection AddProviders(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISecretGeneratorProvider, RandomSecretGeneratorProvider>();

            return serviceCollection;
        }

        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IOTPService, OTPService>();

            return serviceCollection;
        }
    }
}
