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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role(1, "Administrator"));
            modelBuilder.Entity<User>().HasData(new User(1, "Admin"));
            modelBuilder.Entity<UserRole>().HasData(new UserRole(1, 1, 1));

            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UseSoftDelete();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UseSoftDelete();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess,cancellationToken);
        }

        //For table USERS only
        private void UseSoftDelete()
        {
            foreach (var entry in ChangeTracker.Entries<User>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Unchanged:
                        entry.State = EntityState.Unchanged;
                        entry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Modified:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                    default:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;
                }
            }
        }
    }
}
