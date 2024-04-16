namespace BankApp.Business.Converters
{
    public class HOTPConverter : IConverter<long, byte[]>
    {
        public byte[] Convert(long input)
        {
            var bytes = BitConverter.GetBytes(input);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return bytes;
        }
    }
}
