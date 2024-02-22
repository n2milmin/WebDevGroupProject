using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebDevGroupProject.Data;
using WebDevGroupProject.Models;

namespace WebDevGroupProject.Controllers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext _db;
        public SearchController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GeneralSearch(string searchValue, string searchType)
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult TypeResults(string searchType)
        {

            return View();
        }

        [HttpPost]
        public IActionResult GeneralResults(string searchType, string searchValue)
        {
            
            return View();
        }
    }
}
