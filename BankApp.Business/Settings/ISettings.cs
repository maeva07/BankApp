namespace BankApp.Business.Settings
{
    internal interface ISettings
    {
        int TimeStep { get; }
        int Tolerance { get; }
        int DigitLength { get; }
    }
}
