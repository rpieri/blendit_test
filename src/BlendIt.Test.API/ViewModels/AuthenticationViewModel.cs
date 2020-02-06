using BlendIt.Test.Domain.Users.Commands;
using BlendIt.Test.Shared.ViewModels;
using FluentValidation;

namespace BlendIt.Test.API.ViewModels
{
    public class AuthenticationViewModel : ViewModelCommand<AuthenticationCommand>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public override AuthenticationCommand Mapping() => new AuthenticationCommand(Email, Password);

        public override bool Validate()
        {
            InsertValidation(this, new AuthenticationViewModelValidator());
            return ViewModelIsValid();
        }
    }

    internal sealed class AuthenticationViewModelValidator : AbstractValidator<AuthenticationViewModel>
    {
        public AuthenticationViewModelValidator()
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
