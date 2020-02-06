using BlendIt.Test.Domain.Teachers.Commands;
using BlendIt.Test.Shared.ViewModels;
using FluentValidation;

namespace BlendIt.Test.API.ViewModels
{
    public sealed class AddTeacherViewModel : ViewModelCommand<AddTeacherCommand>
    {
        public string Name { get; set; }
        public string Registration { get; set; }
        public override AddTeacherCommand Mapping() => new AddTeacherCommand(Name, Registration);

        public override bool Validate()
        {
            InsertValidation(this, new AddTeacherViewModelValidator());
            return ViewModelIsValid();
        }
    }

    internal sealed class AddTeacherViewModelValidator : AbstractValidator<AddTeacherViewModel>
    {
        public AddTeacherViewModelValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(e => e.Registration)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
