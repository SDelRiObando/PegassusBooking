using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Mvc;
using PegassusBooking.Repositories;
using PegassusBooking.Services;
using PegassusBooking.Utilities;
using PegassusBooking.View;

namespace PegassusBooking.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HospitalsController : Controller
    {
        private readonly IHospital _hospital;
        private readonly ApplicationDBContext _dbContext;
        public HospitalsController(IHospital hospital, ApplicationDBContext DBContext)
        {
            _hospital = hospital;
            _dbContext = DBContext;
        }
        public IActionResult Index(int pageNumber=1, int pageSize = 10)
        {
            return View(_hospital.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var viewModel = _hospital.GetHospitalById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(HospitalViewModel vm) 
        {
            _hospital?.UpdateHospital(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HospitalViewModel vm) 
        {
            _hospital.InsertHospital(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) 
        {
            _hospital.DeleteHospital(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            // Retrieve the hospital information based on the provided id
            var hospital = _hospital.GetHospitalById(id);

            // Check if the hospital is found
            if (hospital == null)
            {
                return NotFound();
            }
            hospital.Rooms = _dbContext.Rooms.Where(r => r.HospitalId == id).ToList();
            hospital.Doctor = _dbContext.ApplicationUsers.Where(d => d.Hospital.Id == id).ToList();
            // Pass the hospital information to the view
            return View(hospital);
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string searchTerm)
        {
            var searchResults = _hospital.SearchHospitals(searchTerm);
            return View("SearchResults", searchResults);
        }
    }
}
