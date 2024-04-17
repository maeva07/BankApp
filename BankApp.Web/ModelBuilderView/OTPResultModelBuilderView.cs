using BankApp.Business.Models;
using BankApp.Web.View;

namespace BankApp.Web.ModelBuilderView
{
    public class OTPResultModelBuilderView
    {
        private readonly OTPResultModelView _viewModel;

        public OTPResultModelBuilderView()
        {
            this._viewModel = new OTPResultModelView();
        }

        public OTPResultModelBuilderView WithValidFrom(DateTime validFrom)
        {
            this._viewModel.ValidFrom = validFrom;

            return this;
        }

        public OTPResultModelBuilderView WithValidUntil(DateTime validUntil)
        {
            this._viewModel.ValidUntil = validUntil;

            return this;
        }

        public OTPResultModelBuilderView WithOTPPassword(string OTPPassword)
        {
            this._viewModel.OTPPassword = OTPPassword;

            return this;
        }

        public OTPResultModelBuilderView WithValidSecondsLeft(int secondsLeft)
        {
            this._viewModel.ValidSecondsLeft = secondsLeft;

            return this;
        }

        public OTPResultModelBuilderView FromOTPResult(OTPResult otpResult)
        {
            this._viewModel.Successful = otpResult != null;

            if (otpResult != null)
                this.WithValidUntil(otpResult.ValidUntil)
                    .WithOTPPassword(otpResult.OTPPassword)
                    .WithValidFrom(otpResult.ValidFrom)
                    .WithValidSecondsLeft(otpResult.ValidSecondsLeft);

            return this;
        }

        public OTPResultModelView Build()
        {
            return this._viewModel;
        }
    }
}
