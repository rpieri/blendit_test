using BlendIt.Test.Domain.Teachers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlendIt.Test.Repository.Mappings
{
    internal class TeacherMapping : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teacher");
            builder.HasKey(x => x.Id).HasName("idTeacher");
            builder.Property(x => x.Code).HasColumnName("code").HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Removed).HasColumnName("removed").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.Registration).HasColumnName("registration").HasColumnType("varchar(50)").IsRequired();
            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.Valid);
            builder.Ignore(x => x.Invalid);
        }
    }
}
