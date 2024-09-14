using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegassusBooking.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string? SSN { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string Zipcode { get; set; }
        public DateOnly DOB { get; set; }
        public string? Specialty { get; set; }
        public Roles Role { get; set; }
        public Insurance? Insurance { get; set; }
        public Hospital? Hospital { get; set; }
        public Department? Department { get; set; }
        [NotMapped]
        public ICollection<Appointment>? Appointments { get; set; }

    }
}
namespace PegassusBooking.Models
{
    public enum Gender
    {
        Male, Female, Other
    }
    public enum Roles
    {
        Patient, Doctor, Admin
    }

    public enum State
    {
        Alabama,
        Alaska,
        Arizona,
        Arkansas,
        California,
        Colorado,
        Connecticut,
        Delaware,
        Florida,
        Georgia,
        Hawaii,
        Idaho,
        Illinois,
        Indiana,
        Iowa,
        Kansas,
        Kentucky,
        Louisiana,
        Maine,
        Maryland,
        Massachusetts,
        Michigan,
        Minnesota,
        Mississippi,
        Missouri,
        Montana,
        Nebraska,
        Nevada,
        NewHampshire,
        NewJersey,
        NewMexico,
        NewYork,
        NorthCarolina,
        NorthDakota,
        Ohio,
        Oklahoma,
        Oregon,
        Pennsylvania,
        RhodeIsland,
        SouthCarolina,
        SouthDakota,
        Tennessee,
        Texas,
        Utah,
        Vermont,
        Virginia,
        Washington,
        WestVirginia,
        Wisconsin,
        Wyoming
    }
}
