using BankApp.Business.Converters;
using BankApp.Business.Settings;

namespace BankApp.Web.Converters
{
    public class ConfigurationToSettingsConverter : IConverter<IConfiguration, ISettings>
    {
        private const string Section = "OTPSettings";

        public ISettings Convert(IConfiguration input)
        {

            var timeStep = int.Parse(GetFromConfiguration(input, "TimeStep"));
            var tolerance = int.Parse(GetFromConfiguration(input, "Tolerance"));
            var digitLength = int.Parse(GetFromConfiguration(input, "DigitLength"));

            var settings = new Settings(timeStep, tolerance, digitLength);

            return settings;
        }

        private string GetFromConfiguration(IConfiguration configuration, string field)
        {
            var key = Format(field);

            return configuration[key];
        }

        private string Format(string field)
        {
            return $"{Section}:{field}";
        }
    }
}
