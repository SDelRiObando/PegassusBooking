using PegassusBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegassusBooking.View
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Hospital Hospital { get; set; }

        public ContactViewModel()
        {
        }

        public ContactViewModel(Contact Model)
        {
            Id = Model.Id;
            HospitalId = Model.HospitalId;
            Email = Model.Email;
            Phone = Model.Phone;
            Hospital = Model.Hospital;
        }
        public Contact ConvertViewModel(ContactViewModel model)
        {
            return new Contact
            {
                Id = model.Id,
                HospitalId = model.HospitalId,
                Email = model.Email,
                Phone = model.Phone,
                Hospital = model.Hospital
            };
        }
    }
}
