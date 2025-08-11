using Domain.Persistance.Configurations;
using Domain.Persistance.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.Generics;

namespace Domain.Persistance
{
    public class ProgramDbContext : DbContext
    {
        public IConfiguration Config { get; set; }

        public ProgramDbContext(IConfiguration config)
        {
            Config = config;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<HomeSlide> HomeSlides { get; set; }
        //public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            CreateDefaultUser(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Config.GetConnectionString("DatabaseConntection"));
        }

        private void CreateDefaultUser(ModelBuilder modelBuilder)
        {
            var passwort = "testpassword1234".HashStringSHA512();

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.Empty,
                Email = "grace-testuser@gmail.com",
                Name = "AdminUser",
                Password = passwort,
                Role = Generics.Enums.UserRole.Admin,
            });
        }
    }
}
