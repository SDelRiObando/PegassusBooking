namespace PegassusBooking.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public string Medicine { get; set; }
        public MedicalReport MedicalReport { get; set; }
    }
}