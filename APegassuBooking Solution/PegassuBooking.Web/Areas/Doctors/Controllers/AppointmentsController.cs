using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PegassusBooking.Models;
using PegassusBooking.Services;
using PegassusBooking.View;

namespace PegassusBooking.Web.Areas.Doctors.Controllers
{
    [Area("Doctors")]
    public class AppointmentsController : Controller
    {
        // GET: Appointments
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

            var pagedResult = _appointments.GetAppointmentsByDoctorId(userId, pageNumber, pageSize);

            // Pass the paged result to the view
            return View(pagedResult);  
        }

        // GET: Appointments/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Appointments/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appointments/Create
        [HttpPost]
        public IActionResult Create(AppointmentViewModel vm)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // Create a new appointment with the current user as the doctor

            // Set other properties as needed
            vm.Doctor = _user.GetUserById(userId);
   
            _appointments.CreateAppointment(vm);

            return RedirectToAction("Index");
        }

        // GET: Appointments/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _appointments.GetAppointmentById(id);
            return View(viewModel);
        }

        // POST: Appointments/Edit/5
        [HttpPost]
        public IActionResult Edit(AppointmentViewModel vm)
        {
            _appointments?.UpdateAppointment(vm);
            return RedirectToAction("Index");
        }

        // GET: Appointments/Delete/5
        public IActionResult Delete(int id)
        {
            _appointments.DeleteAppointment(id);
            return RedirectToAction("Index");
        }
    }
}
