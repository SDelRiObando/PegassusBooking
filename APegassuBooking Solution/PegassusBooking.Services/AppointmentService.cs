using Microsoft.EntityFrameworkCore;
using PegassusBooking.Models;
using PegassusBooking.Repositories;
using PegassusBooking.Repositories.Interfaces;
using PegassusBooking.Repositories.Migrations;
using PegassusBooking.Utilities;
using PegassusBooking.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegassusBooking.Services
{
    public class AppointmentService : IAppointment
    {
        private readonly ApplicationDBContext _context;
        private IUnitOfWork _unitOfWork;

        public AppointmentService(ApplicationDBContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public void CreateAppointment(AppointmentViewModel Appointment)
        {
            var model = new AppointmentViewModel().ConvertViewModel(Appointment);
            _unitOfWork.GenericRepository<Appointment>().Add(model);
            _unitOfWork.Save();
        }

        public void DeleteAppointment(int id)
        {
            var model = _unitOfWork.GenericRepository<Appointment>().GetById(id);
            _unitOfWork.GenericRepository<Appointment>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<AppointmentViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new AppointmentViewModel();
            int totalCount;
            List<AppointmentViewModel> vmList = new List<AppointmentViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Appointment>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Appointment>().GetAll().ToList().Count();

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<AppointmentViewModel>()
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public List<Appointment> GetAll()
        {
            var AppList = _context.Appointments.ToList();
            return AppList;
        }

        public IEnumerable<AppointmentViewModel> GetAllAvailableAppointments()
        {
            var currentDate = DateTime.Now;

            // Retrieve appointments that meet the criteria (e.g., in the future and not booked)
            var availableAppointments = _context.Appointments
                .Where(a => a.ScheduledDate > currentDate && a.Status != Status.Taken)
                .Select(appointment => new AppointmentViewModel
                {
                    Id = appointment.Id,
                    Duration = appointment.Duration,
                    Type = appointment.Type,
                    Doctor  = appointment.Doctor,
                    ScheduledDate = appointment.ScheduledDate,
                    // ...
                })
                .ToList();

            return availableAppointments;
        }

        public AppointmentViewModel GetAppointmentById(int id)
        {
            var model = _unitOfWork.GenericRepository<Appointment>().GetById(id);
            var vm = new AppointmentViewModel(model);
            return vm;
        }

        public PagedResult<AppointmentViewModel> GetAppointmentsByDoctorId(string userId, int pageNumber, int pageSize)
        {
            // Your existing code to retrieve appointments based on the provided doctorId
            var doctorAppointments = _context.Appointments
                .Where(appointment => appointment.Doctor.Id == userId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Convert the Appointment entities to AppointmentViewModel
            var doctorAppointmentsViewModel = ConvertModelToViewModelList (doctorAppointments);


            // Assuming you have the current user's ID available in your HttpContext
            var totalCount = _context.Appointments.Count(appointment => appointment.Doctor.Id == userId);

            var pagedResult = new PagedResult<AppointmentViewModel>
            {
                Data = doctorAppointmentsViewModel,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalCount
            };

            return pagedResult;
        }

        public PagedResult<AppointmentViewModel> GetAppointmentsByPatientId(string userId, int pageNumber, int pageSize)
        {
            // Your existing code to retrieve appointments based on the provided doctorId
            var patientAppointments = _context.Appointments
                .Where(appointment => appointment.Patient.Id == userId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Convert the Appointment entities to AppointmentViewModel
            var patientAppointmentsViewModel = ConvertModelToViewModelList(patientAppointments);


            // Assuming you have the current user's ID available in your HttpContext
            var totalCount = _context.Appointments.Count(appointment => appointment.Patient.Id == userId);

            var pagedResult = new PagedResult<AppointmentViewModel>
            {
                Data = patientAppointmentsViewModel,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalCount
            };

            return pagedResult;
        }

        public void UpdateAppointment(AppointmentViewModel appointment)
        {
            var model = new AppointmentViewModel().ConvertViewModel(appointment);
            var modelById = _unitOfWork.GenericRepository<Appointment>().GetById(model.Id);
            modelById.Number = appointment.Number;
            modelById.Type = appointment.Type;
            modelById.ScheduledDate = appointment.ScheduledDate;
            modelById.Duration = appointment.Duration;
            modelById.Status = appointment.Status;
            modelById.Description = appointment.Description;
            modelById.Doctor = appointment.Doctor;
            modelById.Patient = appointment.Patient;
            _unitOfWork.GenericRepository<Appointment>().Update(modelById);
            _unitOfWork.Save();
        }

        private List<AppointmentViewModel> ConvertModelToViewModelList(List<Appointment> modelList)
        {
            return modelList.Select(x => new AppointmentViewModel(x)).ToList();
        }
    }
}
