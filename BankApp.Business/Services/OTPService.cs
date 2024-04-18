using BankApp.Business.Converters;
using BankApp.Business.Models;
using BankApp.Business.Provider;
using BankApp.Business.Settings;
using System.Security.Cryptography;

namespace BankApp.Business.Services
{
    public class OTPService : IOTPService
    {
        private const byte MaxOffsetLength = 0xf;
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0);
        private readonly long digitModulo;

        private readonly IConverter<long, byte[]> hotpToByteConverter;
        private readonly ISecretGeneratorProvider secretGeneratorProvider;
        private readonly ISettings settings;

        public OTPService( ISettings settings, IConverter<long, byte[]> hotpToByteConverter, ISecretGeneratorProvider secretGeneratorProvider)
        {
            digitModulo = Convert.ToInt64(Math.Pow(10, settings.DigitLength));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.hotpToByteConverter = hotpToByteConverter ?? throw new ArgumentNullException(nameof(OTPService.hotpToByteConverter));
            this.secretGeneratorProvider = secretGeneratorProvider ?? throw new ArgumentNullException(nameof(OTPService.secretGeneratorProvider));
        }

        public OTPResult GenerateOTP(string userId, DateTime? utcDateTime = null)
        {
            if( userId == null ) { throw new ArgumentNullException(nameof(userId)); }

            var dateTime = utcDateTime ?? DateTime.UtcNow;
            var secret = this.secretGeneratorProvider.GenerateSecret(userId);
            var hotpValue = this.ComputeHOTPValue(dateTime);
            var hotpBytes = this.hotpToByteConverter.Convert(hotpValue);
            var hashBytes = GenerateHMACSHA1Hash(hotpBytes, secret);
            var binaryCode = GenerateBinaryCode(hashBytes);

            var otp = binaryCode % this.digitModulo;

            var otpString = otp.ToString().PadLeft(this.settings.DigitLength, '0');
            var otpResult = this.ComputeOTPResult(otpString, dateTime);

            return otpResult;
        }

        public bool ValidateOTP(string userId, string otp)
        {
            var utcNow = DateTime.UtcNow;

            for (var i = 0; i < this.settings.Tolerance; i++)
            {
                var date = utcNow.AddSeconds(-(this.settings.TimeStep * i));
                var generatedOtp = this.GenerateOTP(userId, date);
                if (generatedOtp.OTPPassword == otp) return true;
            }

            return false;
        }

        private static byte[] GenerateHMACSHA1Hash(byte[] hotpBytes, string secret)
        {
            var secretBytes = Convert.FromBase64String(secret);

            var hmacSHA1 = new HMACSHA1(secretBytes);
            var hash = hmacSHA1.ComputeHash(hotpBytes);

            return hash;
        }

        private static int GenerateBinaryCode(IReadOnlyList<byte> hashBytes)
        {
            var offset = GenerateHMACOffset(hashBytes);

            var binaryCode =
                ((hashBytes[offset] & 0x7f) << 24)
                | ((hashBytes[offset + 1] & 0xff) << 16)
                | ((hashBytes[offset + 2] & 0xff) << 8)
                | (hashBytes[offset + 3] & 0xff);

            return binaryCode;
        }   
        
        private static int GenerateHMACOffset(IEnumerable<byte> hash)
        {
            var offset = hash.Last();
            offset &= MaxOffsetLength;

            return offset;
        }

        private long ComputeHOTPValue(DateTime utcDateTime)
        {
            var totpValue = (utcDateTime - UnixEpoch).TotalSeconds / this.settings.TimeStep;
            var totpLongValue = Convert.ToInt64(totpValue);

            return totpLongValue;
        }

        private OTPResult ComputeOTPResult(string otpString, DateTime utcDateTime)
        {
            var dateTime = utcDateTime;

            var second = dateTime.Second;
            if (second >= 15 && second < 45)
            {
                dateTime = dateTime.AddSeconds(-(second - 15));
            }
            else if (second >= 45 && second <= 59)
            {
                dateTime = dateTime.AddSeconds(-(second - 45));
            }
            else if (second >= 0 && second < 15)
            {
                dateTime = dateTime.AddSeconds(-second - 15);
            }

            var validUntil = dateTime.AddSeconds(this.settings.TimeStep);
            var secondsLeft = (int)(validUntil - utcDateTime).TotalSeconds;

            var otpResult = new OTPResult
            {
                OTPPassword = otpString,
                ValidFrom = dateTime,
                ValidUntil = dateTime.AddSeconds(this.settings.TimeStep),
                ValidSecondsLeft = secondsLeft
            };

            return otpResult;
        }
    }
}
