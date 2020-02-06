using BlendIt.Test.Domain.Teachers;
using BlendIt.Test.Domain.Users;
using BlendIt.Test.Repository.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlendIt.Test.Repository.Contexts
{
    public class EntityContext : DbContext
    {
        private readonly IConfiguration configuration;

        public EntityContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public void ExecuteMigrate() => Database.Migrate();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new TeacherMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
