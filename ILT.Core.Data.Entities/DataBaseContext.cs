using ILT.Core.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ILT.Core.Data.Entities
{
    public class DatabaseContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Group>()
                .HasMany(g => g.Users)
                .WithMany(u => u.Groups)
                .UsingEntity<Fellows>(
                    f => f.HasOne(fellow => fellow.User)
                    .WithMany(user => user.Fellows)
                    .HasForeignKey(fellow => fellow.UserId),
                    f => f.HasOne(fellow => fellow.Group)
                    .WithMany(group => group.Fellows)
                    .HasForeignKey(fellow => fellow.GroupId)
                    );
        }
    }
}
