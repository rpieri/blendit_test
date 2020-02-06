using BlendIt.Test.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlendIt.Test.Repository.Mappings
{
    internal sealed class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.Code).HasColumnName("code").HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Removed).HasColumnName("removed").IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(250)").IsRequired();
            builder.Property(x => x.Password).HasColumnName("password").HasColumnType("varchar(100)").IsRequired();
            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.Valid);
            builder.Ignore(x => x.Invalid);
        }
    }
}
