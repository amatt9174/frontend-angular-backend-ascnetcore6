using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Anthony",
                    Email = "anthony@almavitae.org",
                    UserName = "anthony@almavitae.org",
                    Address = new Address
                    {
                        FirstName = "Anthony",
                        LastName = "Matteis",
                        Street = "5946 West State Highway 46",
                        City = "New Braunfels",
                        State = "TX",
                        ZipCode = "78132"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}