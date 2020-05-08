using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace IdentitySample.Models
{
    // This is useful if you do not want to tear down the database each time you run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    // This example shows you how to create a new database if the Model changes
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            Task.Run(async () => { await InitializeIdentityForEF(context); }).Wait();
            context.SaveChanges();
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public async Task InitializeIdentityForEF(ApplicationDbContext db)
        {

            var userManager = new UserManager<User>(new UserStore<User>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var passwordHasher = new Microsoft.AspNet.Identity.PasswordHasher();

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Administrators" });
                await roleManager.CreateAsync(new IdentityRole { Name = "Manager" });
                await roleManager.CreateAsync(new IdentityRole { Name = "Seller" });
            }

            if (!userManager.Users.Any(u => u.UserName == "admin@domain.com"))
            {
                var user = new User
                {
                    Avatar = "avatar-4.png",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Email = "admin@domain.com",
                    UserName = "admin@domain.com",
                    PasswordHash = passwordHasher.HashPassword("Abc@1234"),
                    EmailConfirmed = true,
                    PhoneNumber = "0944551356",
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                await userManager.CreateAsync(user, "Abc@1234");
                await userManager.AddToRoleAsync(user.Id, "Administrators");
                await userManager.AddToRoleAsync(user.Id, "Manager");
                await userManager.AddToRoleAsync(user.Id, "Seller");
            }

            if (!userManager.Users.Any(u => u.UserName == "cong@domain.com"))
            {
                var user = new User
                {
                    Avatar = "avatar-1.png",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Email = "cong@domain.com",
                    UserName = "cong@domain.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0944551356",
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                await userManager.CreateAsync(user, "Abc@1234");
                await userManager.AddToRoleAsync(user.Id, "Administrators");
            }

            if (!userManager.Users.Any(u => u.UserName == "van@domain.com"))
            {
                var user = new User
                {
                    Avatar = "avatar-2.png",
                    Email = "van@domain.com",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    UserName = "van@domain.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0944551356",
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    TwoFactorEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                await userManager.CreateAsync(user, "Abc@1234");
                await userManager.AddToRoleAsync(user.Id, "Manager");
            }
        }
    }
}