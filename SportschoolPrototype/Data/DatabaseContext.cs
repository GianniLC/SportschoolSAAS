using SportschoolPrototype.Models;
using Microsoft.EntityFrameworkCore;

namespace SportschoolPrototype.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<Member> members { get; set; }
        public DbSet<Subscription> subscriptions { get; set; }
        public DbSet<Personel> staff { get; set; }
        public DbSet<Course> courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Subscription>().ToTable("Subscription");
            modelBuilder.Entity<Personel>().ToTable("Staff");
            modelBuilder.Entity<Course>().ToTable("Course");
        }
    }
}