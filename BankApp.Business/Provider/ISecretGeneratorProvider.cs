using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Provider
{
    public interface ISecretGeneratorProvider
    {
        /// <summary>
		/// Generates a secret key to be used in the OTP 
		/// </summary>
		/// <param name="from"></param>
		/// <returns>string version of the key</returns>
		string GenerateSecret(string @from = null);
    }
}
