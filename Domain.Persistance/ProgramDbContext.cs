using Domain.Persistance.Configurations;
using Domain.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.GetConnectionString("DatabaseConntection"));
        }
    }
}
