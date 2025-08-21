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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ColorConfiguration());

            CreateDefaultUser(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        private void CreateDefaultUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.Empty,
                Email = "grace-testuser@gmail.com",
                Name = "AdminUser",
                Password = "testpassword1234".HashStringSHA512(),
                Role = Generics.Enums.UserRole.Admin,
            });
        }
    }
}
