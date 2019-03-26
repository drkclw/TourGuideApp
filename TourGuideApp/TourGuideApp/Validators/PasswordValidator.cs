using System;
using System.Collections.Generic;
using System.Text;
using TourGuideApp.Models;

namespace TourGuideApp.Validators
{
    public class PasswordValidator : IValidationRule<string>
    {
        const int minLength = 6;
        public string Description => $"Password should at least {minLength} characters long.";
        public bool Validate(string value) => !string.IsNullOrEmpty(value) && value.Length >= minLength;
    }
}
