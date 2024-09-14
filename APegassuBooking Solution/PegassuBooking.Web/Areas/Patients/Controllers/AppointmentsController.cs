using Microsoft.AspNetCore.Mvc;
using PegassusBooking.Models;
using PegassusBooking.Services;
using PegassusBooking.View;
using System.Diagnostics;
using System.Drawing.Printing;

namespace PegassusBooking.Web.Areas.Patients.Controllers
{
    [Area("Patients")]
    public class AppointmentsController : Controller
    {
        private readonly IAppointment _appointments;
        private readonly IApplicationUser _user;
        public AppointmentsController(IAppointment appointments, IApplicationUser user)
        {
            _appointments = appointments;
            _user = user;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // Retrieve the user by ID to get the DoctorId

            var pagedResult = _appointments.GetAppointmentsByPatientId(userId, pageNumber, pageSize);

            // Pass the paged result to the view
            return View(pagedResult);
        }
        // GET: Appointments/Select
        public IActionResult Select()
        {
            // Retrieve all available appointments
            var availableAppointments = _appointments.GetAllAvailableAppointments();

            // Pass the available appointments to the view
            return View(availableAppointments);
        }

        // POST: Appointments/Select
        [HttpPost]
        public IActionResult Select(int selectedAppointmentId)
        {
            // Logic to handle the selected appointment
            // This could involve updating the database, creating a new record, etc.
            Debug.WriteLine("ID:" + selectedAppointmentId);
            // Redirect to a confirmation page or take any other necessary actions
            return RedirectToAction("Edit", new { id = selectedAppointmentId });
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Debug.WriteLine("ID:" + id);
            // Retrieve the appointment information based on the provided id
            var viewModel = _appointments.GetAppointmentById(id);
            // Pass the appointment information to the Edit view
            Debug.WriteLine("BEFOREEEEEEEEEEEEEEEEEEE");

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(AppointmentViewModel vm)
        {
            Debug.WriteLine("AFFFFFFFFFteREEEEEEEEEEEEEEEEEEE");

            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
Debug.WriteLine("userID: " + userId);

            // Pass the appointment information to the Edit view
            vm.Patient = _user.GetUserById(userId);

            vm.Status = Status.Taken;

            _appointments.UpdateAppointment(vm);
            return View("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // Retrieve the appointment by id
            var viewModel = _appointments.GetAppointmentById(id);

            // Check if the appointment exists
            if (viewModel == null)
            {
                return NotFound();
            }

            // Set the appointment properties to mark it as available
            viewModel.Patient = null;
            viewModel.Status = Status.Available;
            viewModel.Description = string.Empty;

            // Update the appointment in the database
            _appointments.UpdateAppointment(viewModel);

            return RedirectToAction("Index");
        }
    }
}
