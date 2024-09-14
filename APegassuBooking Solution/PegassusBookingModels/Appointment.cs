namespace PegassusBooking.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string? Type { get; set; }
        public DateTimeOffset ScheduledDate { get; set; }
        public int Duration { get; set; }
        public Status Status { get; set; }
        public string? Description { get; set; }
        public ApplicationUser Doctor { get; set; }
        public ApplicationUser? Patient { get; set; }
    }
}