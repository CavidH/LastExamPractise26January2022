using FluentValidation;
using LastExamPractise26January2022.Areas.AdminDoc.ViewModels;

namespace LastExamPractise26January2022.Areas.AdminDoc.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterVM>
    {
        public RegisterValidator()
        {
            RuleFor(p => p.FullName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(255);
            RuleFor(p => p.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();
            RuleFor(p => p.Password)
              .NotEmpty()
              .NotNull();


        }
    }
}
