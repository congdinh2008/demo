using System.Data.Entity;
using DemoIdentityAdvanced.Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DemoIdentityAdvanced.UI.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DemoIdentityAdvancedConn", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database initializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");

            modelBuilder.Entity<Post>().HasMany(p => p.Tags).WithMany(t => t.Posts).Map(
                pt =>
                {
                    pt.MapLeftKey("PostId");
                    pt.MapRightKey("TagId");
                    pt.ToTable("PostTags");
                });
        }
    }
}