using Microsoft.Extensions.DependencyInjection;

namespace BankApp
{
    public class ModuleInitialization 
    {
        public static IServiceCollection InitializeEngine(IServiceCollection serviceCollection)
        {
            var bootstrapper = new Bootstrapper(serviceCollection);

            var updatedServiceCollection = bootstrapper.Initialize();

            return updatedServiceCollection;
        }

        static async Task Main()
        {
             
        }
    }

}
