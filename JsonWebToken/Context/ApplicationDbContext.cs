using JsonWebToken.Models;
using Microsoft.EntityFrameworkCore;

namespace JsonWebToken.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("JWTUser");
            modelBuilder.Entity<User>().HasData(
                new User { Id=1 ,Username="Adir",Password="1111"}
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
