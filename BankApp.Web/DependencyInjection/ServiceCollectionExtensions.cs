using BankApp.Web.Converters;
using BankApp.Web.ModelBuilderView;

namespace BankApp.Web.DependencyInjection
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSettings( this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var settings = new ConfigurationToSettingsConverter().Convert(configuration);
            serviceCollection.AddSingleton(settings);

            return serviceCollection;
        }

        public static IServiceCollection AddViewModelBuilders(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<OTPResultModelBuilderView>();

            return serviceCollection;
        }
    }
}
