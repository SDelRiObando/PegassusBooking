using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PegassusBooking.Models;
using PegassusBooking.Services;
using PegassusBooking.View;

namespace PegassusBooking.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomsController : Controller
    {
        private readonly IRoom _room;
        private readonly IHospital _hospital;
        public RoomsController(IRoom room, IHospital hospital) 
        {
            _room = room;
            _hospital = hospital;
        }
        public IActionResult Index(int pageNumber=1, int pageSize = 10)
        {
            return View(_room.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.hospital = new SelectList(_hospital.GetAll(), "Id", "Name");
            var viewModel = _room.GetRoomById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(RoomViewModel vm)
        {
            _room?.UpdateRoom(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.hospital = new SelectList(_hospital.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(RoomViewModel vm)
        {
            _room.InsertRoom(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _room.DeleteRoom(id);
            return RedirectToAction("Index");
        }
    }
}
