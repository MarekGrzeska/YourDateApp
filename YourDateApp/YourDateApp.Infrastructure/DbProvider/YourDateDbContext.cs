using Microsoft.EntityFrameworkCore;
using YourDateApp.Domain.Entities;

namespace YourDateApp.Infrastructure.DbProvider
{
    public class YourDateDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public YourDateDbContext(DbContextOptions<YourDateDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Profile);
        }
    }
}
