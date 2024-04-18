using System.Security.Cryptography;

namespace BankApp.Business.Provider
{
    public class RandomSecretGeneratorProvider : ISecretGeneratorProvider
    {
        private readonly int _keyLength;

        public RandomSecretGeneratorProvider(int keyLength)
        {
            this._keyLength = keyLength;
        }

        protected virtual string GenerateRandomKey(int length)
        {
            var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[length];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        public virtual string GenerateSecret(string @from = null)
        {
            return this.GenerateRandomKey(this._keyLength);
        }
    }
}
