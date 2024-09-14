using Microsoft.AspNetCore.Mvc;

namespace PegassusBooking.Web.Areas.Doctors.Controllers
{
    [Area("Doctors")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
