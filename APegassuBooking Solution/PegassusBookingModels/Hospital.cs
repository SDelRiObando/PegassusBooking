using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegassusBooking.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Type { get; set; }
        [NotMapped]
        public ICollection<ApplicationUser> Doctor { get; set; }
        [NotMapped]
        public ICollection<Room> Rooms { get; set; }
        [NotMapped]
        public ICollection<Contact> Contacts { get; set; }
        [NotMapped]
        public ICollection<Insurance> Insurances { get; set; }
    }
}
