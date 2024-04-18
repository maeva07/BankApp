namespace BankApp.Business.Provider
{
    public interface ISecretGeneratorProvider
    {
		string GenerateSecret(string @from = null);
    }
}
