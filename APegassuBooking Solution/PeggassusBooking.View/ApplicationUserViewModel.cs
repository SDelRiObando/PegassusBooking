using PegassusBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegassusBooking.View
{
    public class ApplicationUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? UserName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string SSN { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string Zipcode { get; set; }
        public DateOnly DOB { get; set; }
        public string Specialty { get; set; }
        public Roles Role { get; set; }
        public Hospital Hospital { get; set; }
        public ApplicationUserViewModel()
        {

        }
        public ApplicationUserViewModel(ApplicationUser user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            Email = user.Email;
            Gender = user.Gender;
            SSN = user.SSN;
            DOB = user.DOB;
            Street = user.Street;
            City = user.City.ToString();
            State = user.State;
            Zipcode = user.Zipcode.ToString();
            Specialty = user.Specialty.ToString();
            Role = user.Role;
            Hospital = user.Hospital;
        }
        public ApplicationUser ConvertViewModelToModel(ApplicationUserViewModel user)
        {
            return new ApplicationUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Gender = user.Gender,
                SSN = user.SSN,
                DOB = user.DOB,
                Street = user.Street,
                City = user.City.ToString(),
                State = user.State,
                Zipcode = user.Zipcode.ToString(),
                Specialty = user.Specialty.ToString(),
                Role = user.Role,
                Hospital = user.Hospital
            };
        }

        public List<ApplicationUser> Doctors { get; set; } = new List<ApplicationUser>();
    }
}
