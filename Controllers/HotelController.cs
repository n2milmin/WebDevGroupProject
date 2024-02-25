using Microsoft.AspNetCore.Mvc;
using WebDevGroupProject.Models;

namespace WebDevGroupProject.Controllers
{
    public class HotelController : Controller
    {
        private readonly AppDbContext _db;

        public HotelController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            Hotel hotel = _db.Hotels.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _db.Hotels.Add(hotel);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotel);
        }
    }
}
