using AmonicAirlinesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace AmonicAirlinesAPI.Validators
{
    public class Unique : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var email = (string)value!;
            AmonicAirlinesContext dbContext = (AmonicAirlinesContext)validationContext.GetService(typeof(AmonicAirlinesContext))!;

            if (dbContext.Users.Where(x => x.Email == email).Count() > 0)
                return new ValidationResult(ErrorMessageString);

            return ValidationResult.Success;
        }
    }
}
