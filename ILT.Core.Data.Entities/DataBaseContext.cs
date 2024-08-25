using ILT.Core.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ILT.Core.Data.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options){}
        public DatabaseContext(){}

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
