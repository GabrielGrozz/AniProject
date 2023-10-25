using AniProject.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Identity;

namespace AniProject.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        public readonly UserManager<IdentityUser> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if ( !_roleManager.RoleExistsAsync("Member").Result )
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Member";
                role.NormalizedName = "MEMBER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()
        {
             if ( _userManager.FindByEmailAsync("admingabriel@localhost.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admingabriel@localhost.com";
                user.Email = "admingabriel@localhost.com";
                user.NormalizedUserName = "ADMINGABRIEl@LOCALHOST.COM";
                user.NormalizedEmail = "ADMINGABRIEl@LOCALHOST.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Password@123").Result;

                if ( result.Succeeded )
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait() ;
                }
            }

            if (_userManager.FindByEmailAsync("user@localhost@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "user@localhost.com";
                user.Email = "user@localhost.com";
                user.NormalizedUserName = "USER@LOCALHOST.COM";
                user.NormalizedEmail = "USER@LOCALHOST.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Password@123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Member").Wait();
                }
            }
        }
    }
}
