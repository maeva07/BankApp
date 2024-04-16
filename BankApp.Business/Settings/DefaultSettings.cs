namespace BankApp.Business.Settings
{
    internal class DefaultSettings : ISettings
    {
        public int TimeStep { get; } = 30;
        public int Tolerance { get; } = 3;
        public int DigitLength { get; } = 6;
    }
}
