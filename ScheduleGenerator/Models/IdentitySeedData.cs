using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ScheduleGenerator.Models
{
    public static class IdentitySeedData
    {
        private static string[] FirstName = new string[] {"Pasquale", "Sheldon", "Marcelina", "Lola","Marty",
                                                   "Olive", "Lucie", "Albert", "Lance","Retta",
                                                   "Daniele", "Eliseo", "Shawn", "See", "Salina",
                                                   "Dalton", "Irena", "Octavio", "Patrick", "Carl"};

        private static string[] LastName = new string[] {"Reiber", "Largent", "Murdock", "Carrick","Mccandless",
                                                  "Tirrell","Soo","Kale","Riley","Boll",
                                                  "Domingues","Scull","Magill","Primm","Senecal",
                                                  "Kemp","Leeks","Racette","Caver","Broker"};

        private static string[] Phone = new string[] { "6135550172", "9157764374",  "8568218707", "7682581970", "2237252244",
                                                    "9718517738", "4227324536", "9716583866", "7045453270", "2346826636",
                                                    "3539488473", "2597871718", "4515035995", "7076506888", "5106538813",
                                                    "2455246568", "3625682042", "3256841854", "8897820099", "9782448494"};

        private static string[] Department = new string[] {"ADMIN","COMP","COMM","MATH","COMM",
                                                    "COMM","COMM","MATH","MATH","MATH",
                                                    "COMP", "COMP", "COMP", "COMP", "COMP",
                                                    "COMP", "COMP", "COMP", "COMP", "COMP"};

        private static string[] RoleName = new string[] {"ADMIN","COORDINATOR", "COORDINATOR", "COORDINATOR", "INSTRUCTOR",
                                                    "INSTRUCTOR","INSTRUCTOR","INSTRUCTOR","INSTRUCTOR","INSTRUCTOR",
                                                    "INSTRUCTOR","INSTRUCTOR","INSTRUCTOR","INSTRUCTOR","INSTRUCTOR",
                                                    "INSTRUCTOR","INSTRUCTOR","INSTRUCTOR","INSTRUCTOR","INSTRUCTOR" };

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using(IServiceScope scope = app.ApplicationServices.CreateScope())
            {
                AppIdentityDbContext context = app.ApplicationServices.GetRequiredService<AppIdentityDbContext>();
                context.Database.EnsureCreated();

                UserManager<AppUser> userManager = scope.ServiceProvider
                    .GetRequiredService<UserManager<AppUser>>();

                RoleManager<IdentityRole> roleManager = scope.ServiceProvider
                    .GetRequiredService<RoleManager<IdentityRole>>();

                for (int index = 0; index < FirstName.Length; index++)
                {

                    AppUser user = await userManager.FindByIdAsync(             //Check if the user already exist
                        FirstName[index] + Department[index] + "@college.com"); // Username = FirstName+Department+@college.com
                                                                                // IE: PasqualeADMIN@college.com

                    IdentityRole newRole = await roleManager.FindByNameAsync(RoleName[index]); //Check if the role already exist

                    if (newRole == null) // If the role does not exist
                    {
                        newRole = new IdentityRole(RoleName[index]); //Creates the role
                        await roleManager.CreateAsync(newRole);// Saves the role
                    }

                    if (user == null)
                    {
                        user = new AppUser();
                        user.UserName = FirstName[index] + Department[index] + "@college.com";
                        user.FirstName = FirstName[index];
                        user.LastName = LastName[index];
                        user.PhoneNumber = Phone[index];
                        user.Department = Department[index];
                        //user.PasswordHash="Secret123$";
                        await userManager.CreateAsync(user, "Secret123$");
                        await userManager.AddToRoleAsync(user, RoleName[index]);
                    }
                }
            }
            
        }
    }
}
