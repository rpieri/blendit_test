using BlendIt.Test.Domain.Teachers.Commands;
using BlendIt.Test.Shared.ViewModels;
using FluentValidation;
using System;

namespace BlendIt.Test.API.ViewModels
{
    public class UpdateTeacherViewModel : ViewModelCommand<UpdateTeacherCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Registration { get; set; }
        public override UpdateTeacherCommand Mapping() => new UpdateTeacherCommand(Id, Name, Registration);

        public override bool Validate()
        {
            InsertValidation(this, new UpdateTeacherViewModelValidator());
            return ViewModelIsValid();
        }
    }
    internal sealed class UpdateTeacherViewModelValidator : AbstractValidator<UpdateTeacherViewModel>
    {
        public UpdateTeacherViewModelValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty();

            RuleFor(e => e.Name)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(e => e.Registration)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
