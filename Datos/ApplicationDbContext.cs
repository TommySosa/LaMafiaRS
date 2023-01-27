using LaMafiaRS.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace LaMafiaRS.Datos
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tweet>()
                .HasOne(p => p.User)
                .WithMany(u => u.Tweet)
                .HasForeignKey(p => p.UserId);
        }
        public DbSet<User> User { get; set; }
        public DbSet<Tweet> Tweet { get; set; }
    }

}
