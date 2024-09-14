using PegassusBooking.Models;
using PegassusBooking.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegassusBooking.Services
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly ApplicationDBContext _dbContext;  // Replace YourDbContext with your actual DbContext type

        public ApplicationUserService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ApplicationUser GetUserById(string userId)
        {
            return _dbContext.ApplicationUsers.FirstOrDefault(u => u.Id == userId);
        }
    }
}
