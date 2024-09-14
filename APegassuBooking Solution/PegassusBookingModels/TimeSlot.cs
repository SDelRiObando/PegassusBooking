using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegassusBooking.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public ApplicationUser DoctorId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int ShiftStartTime { get; set; }
        public int ShiftEndTime { get; set; }
        public Status Status { get; set; }
    }
}

namespace PegassusBooking.Models
{
    public enum Status
    {
        Available, Taken, Complete
    }
}
