﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebDevGroupProject.Models;

namespace WebDevGroupProject.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
