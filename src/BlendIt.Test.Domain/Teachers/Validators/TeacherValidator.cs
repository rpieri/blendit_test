using FluentValidation;

namespace BlendIt.Test.Domain.Teachers.Validators
{
    internal sealed class TeacherValidator : AbstractValidator<Teacher>
    {
        public TeacherValidator()
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
