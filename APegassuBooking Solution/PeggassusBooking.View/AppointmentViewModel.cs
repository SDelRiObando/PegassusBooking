using PegassusBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegassusBooking.View
{
    public class AppointmentViewModel
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

        public AppointmentViewModel() 
        { 
        }
        
        public AppointmentViewModel(Appointment model)
        {
            Id = model.Id;
            Number = model.Number;
            Type = model.Type;
            ScheduledDate = model.ScheduledDate;
            Duration = model.Duration;
            Status = model.Status;
            Description = model.Description;
            Doctor = model.Doctor;
            Patient = model.Patient;
        }
        public Appointment ConvertViewModel(AppointmentViewModel model)
        {
            return new Appointment
            {
                Id = model.Id,
                Number = model.Number,
                Type = model.Type,
                ScheduledDate = model.ScheduledDate,
                Duration = model.Duration,
                Status = model.Status,
                Description = model.Description,
                Doctor = model.Doctor,
                Patient = model.Patient
            };
        }
    }
}
