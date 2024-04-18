namespace BankApp.Business.Settings
{
    public class Settings : ISettings
    {
        public int TimeStep { get; }
        public int Tolerance { get; }
        public int DigitLength { get; }

        public Settings(int timeStep, int tolerance, int digitLength)
        {
            this.TimeStep = timeStep;
            this.Tolerance = tolerance;
            this.DigitLength = digitLength;
        }
    }
}
