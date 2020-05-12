using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionDemo.Core
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext() : base("DemoConn")
        {

        }

        static DemoDbContext()
        {
            Database.SetInitializer<DemoDbContext>(new DbInitializer());
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            OnBeforeSaving();
            return base.SaveChangesAsync();
        }

        private void OnBeforeSaving()
        {

            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Modified:

                        // Set the modified date to "now"
                        ((BaseEntity)entityEntry.Entity).ModifiedDate = DateTime.Now;

                        // Mark property as "don't touch"; don't want to update on a Modify operation
                        entityEntry.Property("CreatedDate").IsModified = false;

                        break;

                    case EntityState.Added:

                        // set both updated &amp; created date to "now"
                        ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;

                        ((BaseEntity)entityEntry.Entity).ModifiedDate = DateTime.Now;

                        break;
                }
            }
        }
    }
}
