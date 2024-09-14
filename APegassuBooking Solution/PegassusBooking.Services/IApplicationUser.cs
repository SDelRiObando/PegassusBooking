using PegassusBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegassusBooking.Services
{
    public interface IApplicationUser
    {
        ApplicationUser GetUserById(string userId);
    }
}
