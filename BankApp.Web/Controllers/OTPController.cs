using BankApp.Business.Services;
using BankApp.Web.ModelBuilderView;
using BankApp.Web.View;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OTPController : ControllerBase
    {
        private readonly IOTPService _otpService;
        private readonly OTPResultModelBuilderView _viewModelBuilder;

        public OTPController(IOTPService otpService, OTPResultModelBuilderView viewModelBuilder)
        {
            this._otpService = otpService;
            this._viewModelBuilder = viewModelBuilder;
        }

        [HttpGet]
        public OTPResultModelView Get(string userId, DateTime? dateTime)
        {
            var utcDateTime = dateTime ?? DateTime.UtcNow;

            var otpResult = this._otpService.GenerateOTP(userId, utcDateTime);

            var viewModel = this._viewModelBuilder
                .FromOTPResult(otpResult)
                .Build();

            return viewModel;
        }
    }
}
