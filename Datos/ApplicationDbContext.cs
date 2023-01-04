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
            modelBuilder.Entity<User>()
                .HasMany(b => b.Tweet)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
        }
        public DbSet<User> User { get; set; }
    }

}
