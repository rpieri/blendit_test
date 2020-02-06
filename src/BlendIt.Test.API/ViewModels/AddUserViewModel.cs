using BlendIt.Test.Domain.Users.Commands;
using BlendIt.Test.Shared.ViewModels;
using FluentValidation;

namespace BlendIt.Test.API.ViewModels
{
    public sealed class AddUserViewModel : ViewModelCommand<AddUserCommand>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public override AddUserCommand Mapping() => new AddUserCommand(Email, Password);

        public override bool Validate()
        {
            InsertValidation(this, new AddUserViewModelValidator());
            return ViewModelIsValid();
        }
    }

    internal sealed class AddUserViewModelValidator: AbstractValidator<AddUserViewModel>
    {
        public AddUserViewModelValidator()
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
