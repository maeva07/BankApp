using BankApp.Business.Models;

namespace BankApp.Business.Services
{
    internal interface IOTPService
    {
        OTPResult GenerateOTP(string userId, DateTime? utcDateTime = null);

        bool ValidateOTP(string userId, string otp);
    }
}
