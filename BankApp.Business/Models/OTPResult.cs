﻿namespace BankApp.Business.Models 
{
    public class OTPResult
    {
        public string OTPPassword { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public int ValidSecondsLeft { get; set; }
    }
}