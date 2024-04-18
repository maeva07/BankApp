using BankApp.Business.Converters;
using BankApp.Business.Provider;
using BankApp.Business.Services;
using BankApp.Business.Settings;
using Moq;

namespace BankApp.Tests.ServiceTests
{
    [TestClass]
    public class ConstructorTests
    {
        private readonly Mock<IConverter<long, byte[]>> converter;
        private readonly Mock<ISecretGeneratorProvider> secretGeneratorProvider;
        private readonly Mock<ISettings> settings;

        public ConstructorTests()
        {
            converter = new Mock<IConverter<long, byte[]>>();
            secretGeneratorProvider = new Mock<ISecretGeneratorProvider>();
            settings = new Mock<ISettings>();   
        }

        [TestMethod] 
        public void HavingNullConverter_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new OTPService( settings.Object, null, secretGeneratorProvider.Object);
            });
        }

        [TestMethod]
        public void HavingNullSettings_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<NullReferenceException>(() =>
            {
                new OTPService(null, converter.Object, secretGeneratorProvider.Object);
            });
        }
        [TestMethod]
        public void HavingNullGenerator_WhenCallingConstructor_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new OTPService(settings.Object, converter.Object, null);
            });
        }
    }
}