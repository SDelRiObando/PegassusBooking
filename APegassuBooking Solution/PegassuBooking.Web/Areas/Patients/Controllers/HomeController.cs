using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace PegassusBooking.Web.Areas.Patients.Controllers
{
    [Area("Patients")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Debug.Print("In the PatientIndex\nIn the PatientIndex\nIn the PatientIndex\nIn the PatientIndex\n");
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
