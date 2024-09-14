using PegassusBooking.Models;
using PegassusBooking.Utilities;
using PegassusBooking.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegassusBooking.Services
{
    public interface IAppointment
    {
        PagedResult<AppointmentViewModel> GetAll(int pageNumber, int pageSize);
        AppointmentViewModel GetAppointmentById(int id);
        void UpdateAppointment(AppointmentViewModel appointment);
        void CreateAppointment(AppointmentViewModel Appointment);
        void DeleteAppointment(int id);
        List<Appointment> GetAll();
        PagedResult<AppointmentViewModel> GetAppointmentsByPatientId(string userId, int pageNumber, int pageSize);
        PagedResult<AppointmentViewModel> GetAppointmentsByDoctorId(string userId, int pageNumber, int pageSize);
        IEnumerable<AppointmentViewModel> GetAllAvailableAppointments();
    }
}
