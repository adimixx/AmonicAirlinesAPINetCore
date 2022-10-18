namespace AmonicAirlinesAPI.Validators
{
    using AmonicAirlinesAPI.Models;
    using FluentValidation;

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.Email).EmailAddress().NotNull();
            RuleFor(x => x.OfficeId).NotNull();
            RuleFor(x => x.RoleId).NotNull().When(x => x.Id > 0);
            RuleFor(x => x.Birthdate).NotNull().LessThan(x => DateTime.Now).When(x => x.Id <= 0);
        }
    }
}
