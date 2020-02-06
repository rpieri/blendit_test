using FluentValidation;

namespace BlendIt.Test.Domain.Users.Validations
{
    internal sealed class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(e => e.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(250);

            RuleFor(e => e.Password)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
