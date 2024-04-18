using BankApp.Business.Converters;
using BankApp.Business.Provider;
using BankApp.Business.Services;
using BankApp.Business.Settings;
using Microsoft.Extensions.Configuration;
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
            serviceCollection.AddTransient<ISecretGeneratorProvider>(provider =>
                                new RandomSecretGeneratorProvider(keyLength: 16));
           

            return serviceCollection;
        }

        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IOTPService, OTPService>();

            serviceCollection.AddSingleton<ISettings>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var timeStep = int.Parse(configuration["OTPSettings:TimeStep"]);
                var tolerance = int.Parse(configuration["OTPSettings:Tolerance"]);
                var digitLength = int.Parse(configuration["OTPSettings:DigitLength"]);

                return new Settings(timeStep, tolerance, digitLength);
            });

            return serviceCollection;
        }
    }
}
