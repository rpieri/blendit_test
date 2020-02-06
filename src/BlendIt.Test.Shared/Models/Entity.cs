using FluentValidation;
using FluentValidation.Results;
using System;

namespace BlendIt.Test.Shared.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            Removed = false;
            Valid = true;

            var random = new Random();
            var date = DateTime.UtcNow;
            Code = $"{date.Year}{date.Month}{date.Day}-{date.Hour}{date.Minute}{date.Second}{date.Millisecond}-{random.Next(1, 150000)}";
        }

        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public bool Removed { get; private set; }


        public bool Valid { get; private set; }
        public ValidationResult ValidationResult { get; private set; }
        public bool Invalid => !Valid;

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator) where TModel : Entity
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            if (compareTo is null)
            {
                return false;
            }

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b) => !(a == b);
        public override int GetHashCode() => (GetType().GetHashCode() * 987) + Code.GetHashCode();
        public virtual void Remove() => Removed = true;
    }
}
