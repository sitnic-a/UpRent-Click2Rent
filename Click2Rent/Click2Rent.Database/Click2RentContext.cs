using Click2Rent.Domain;
using Microsoft.EntityFrameworkCore;

namespace Click2Rent.Database
{
    public class Click2RentContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public Click2RentContext(){}

        public Click2RentContext(DbContextOptions<Click2RentContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=.;Database=Click2RentDB;Trusted_Connection=True;TrustServerCertificate=True;");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role(1, "Administrator"));
            modelBuilder.Entity<User>().HasData(new User(1, "Admin"));
            modelBuilder.Entity<UserRole>().HasData(new UserRole(1, 1, 1));

            base.OnModelCreating(modelBuilder);

        }
    }
}
