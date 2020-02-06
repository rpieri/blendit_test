using BlendIt.Test.Domain.Teachers.Validators;
using BlendIt.Test.Shared.Models;

namespace BlendIt.Test.Domain.Teachers
{
    public sealed class Teacher : Entity
    {
        public Teacher(string name, string registration)
        {
            Update(name, registration);
        }

        public string Name { get; private set; }
        public string Registration { get; private set; }

        public void Update(string name, string registration)
        {
            Name = name;
            Registration = registration;
            Validate(this, new TeacherValidator());
        }
    }
}
