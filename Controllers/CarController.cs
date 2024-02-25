using Microsoft.AspNetCore.Mvc;
using WebDevGroupProject.Models;

namespace WebDevGroupProject.Controllers
{
    public class CarController : Controller
    {
        private readonly AppDbContext _db;

        public CarController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<CarRental> car = _db.CarRentals.ToList();
            return View(car);
        }

        public ActionResult Details(int id)
        {
            CarRental car = _db.CarRentals.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarRental car)
        {
            if (ModelState.IsValid)
            {
                _db.CarRentals.Add(car);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }
    }
}
