using Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SeedData
{
    public  class SeedUserAsync
    {
        public static async Task SeedUser(UserManager<User> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new User()
                {
                    UserName = "Admin@gmail.com",
                    Email = "Admin@gmail.com",
                    PhoneNumber = "0797237416",
                    City = "Amman"
                };

                await userManager.CreateAsync(user, "Admin.123");
            }
          
        }
    }
}
