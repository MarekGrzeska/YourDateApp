using Microsoft.EntityFrameworkCore;
using YourDateApp.Domain.Entities;

namespace YourDateApp.Infrastructure.DbProvider
{
    public class YourDateDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }

        public YourDateDbContext(DbContextOptions<YourDateDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Profile);

            modelBuilder.Entity<Like>();
            modelBuilder.Entity<Chat>()
                .HasMany(c => c.Messages)
                .WithOne(m => m.Chat)
                .HasForeignKey(ms => ms.ChatId);
        }
    }
}