namespace BankApp.Business.Settings
{
    public interface ISettings
    {
        int TimeStep { get; }
        int Tolerance { get; }
        int DigitLength { get; }
    }
}
