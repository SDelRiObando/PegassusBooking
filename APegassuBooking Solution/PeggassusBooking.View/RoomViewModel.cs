using PegassusBooking.Models;

namespace PegassusBooking.View
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public string Status { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        public RoomViewModel() 
        {
        }

        public RoomViewModel(Room Model) 
        {
            Id = Model.Id;
            RoomNumber = Model.RoomNumber;
            RoomType = Model.RoomType;
            Status = Model.Status;
            HospitalId = Model.HospitalId;
            Hospital = Model.Hospital;
        }
        public Room ConvertViewModel(RoomViewModel model)
        {
            return new Room
            {
                Id = model.Id,
                RoomNumber = model.RoomNumber,
                RoomType = model.RoomType,
                Status = model.Status,
                HospitalId = model.HospitalId,
                Hospital = model.Hospital
            };
        }
    }
}
