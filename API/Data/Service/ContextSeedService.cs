using API.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Service
{
    public class ContextSeedService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ContextSeedService(ApplicationDbContext context,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeContextAsync()
        {
            if (_context.Database.GetPendingMigrationsAsync().GetAwaiter().GetResult().Count() > 0)
            {
                await _context.Database.MigrateAsync();
            }

            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = SD.AdminRole });
                await _roleManager.CreateAsync(new IdentityRole { Name = SD.TeacherRole });
            }

            if (!_userManager.Users.AnyAsync().GetAwaiter().GetResult())
            {

                var teacher = new User
                {
                    FirstName = "Sarah",
                    LastName = "Petterson",
                    UserName = "SarahP",
                    Email = "sarahp@es.com",
                    EmailConfirmed = true
                };
                await _userManager.CreateAsync(teacher, "123456");
                await _userManager.AddToRoleAsync(teacher, SD.TeacherRole);
                await _userManager.AddClaimsAsync(teacher, new Claim[]
                {
                    new Claim(ClaimTypes.Email, teacher.Email),
                    new Claim(ClaimTypes.Name, teacher.UserName)
                });

                var admin = new User
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "admin",
                    Email = "admin@es.com",
                    AccountStatus = "Confirmed",
                    EmailConfirmed = true
                };
                await _userManager.CreateAsync(admin, "Pa$$w0rd");
                await _userManager.AddToRoleAsync(admin, SD.AdminRole);
                await _userManager.AddClaimsAsync(admin, new Claim[]
                {
                    new Claim(ClaimTypes.Email, admin.Email),
                    new Claim(ClaimTypes.Name, admin.UserName)
                });


            }
        }
    }
}
