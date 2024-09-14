using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PegassusBooking.Models;
using PegassusBooking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegassusBooking.Utilities
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDBContext _context;

        public DbInitializer(UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            ApplicationDBContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if(_context.Database.GetPendingMigrations().Count() > 0)
                { 
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }

            if (!_roleManager.RoleExistsAsync(WebsiteRoles.Website_Admin).GetAwaiter().GetResult()) 
            {
                _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.Website_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.Website_Patient)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.Website_Doctor)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser 
                {
                    UserName = "santi",
                    Email = "santi@xyz.com"
                }, "santi@123").GetAwaiter().GetResult();

                var AppUser = _context.ApplicationUsers.FirstOrDefault(x => x.Email == "santi@xyz.com");
                if(AppUser != null)
                {
                    _userManager.AddToRoleAsync(AppUser, WebsiteRoles.Website_Admin).GetAwaiter().GetResult();
                }
            }
        }
    }
}
