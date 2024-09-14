namespace PegassusBooking.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public string Status { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }

    }
}