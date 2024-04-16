using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace BankApp
{
    public class Program 
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
