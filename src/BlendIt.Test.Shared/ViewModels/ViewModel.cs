using FluentValidation;
using FluentValidation.Results;

namespace BlendIt.Test.Shared.ViewModels
{
    public abstract class ViewModel
    {
        public ViewModel()
        {
            Valid = true;
        }
        public bool Valid { get; private set; }
        public ValidationResult ValidationResult { get; protected set; }
        public bool Invalid => !Valid;

        protected bool ViewModelIsValid() => Valid == ValidationResult.IsValid;
        protected void InsertValidation<TViewModel>(TViewModel model, AbstractValidator<TViewModel> validator) where TViewModel : ViewModel
            => ValidationResult = validator.Validate(model);

        public abstract bool Validate();
    }
}
