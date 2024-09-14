using PegassusBooking.Models;

namespace PegassusBooking.View
{
    public class HospitalViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Type { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<ApplicationUser> Doctor { get; set; }
        public HospitalViewModel() {
        }
        public HospitalViewModel(Hospital model) 
        {
            Id = model.Id;
            Name = model.Name;
            Street = model.Street;
            City = model.City;
            State = model.State;
            Zipcode = model.Zipcode;
            Type = model.Type;
            Rooms = model.Rooms;
            Doctor = model.Doctor;
        }
        public Hospital ConvertViewModel(HospitalViewModel model)
        {
            return new Hospital{
                Id = model.Id,
                Name = model.Name,
                Street = model.Street,
                City = model.City,
                State = model.State,
                Zipcode = model.Zipcode,
                Type = model.Type,
                Rooms = model.Rooms,
                Doctor = model.Doctor,
            };
        }
    }
}
