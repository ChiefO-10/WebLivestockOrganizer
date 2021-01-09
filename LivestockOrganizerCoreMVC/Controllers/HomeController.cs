using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LivestockOrganizerCoreMVC.Models;
using WebLivestockOrganizer.Models;

namespace LivestockOrganizerCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult AnimalRaport()
        {
            return View();
        }
        public IActionResult Table()
        {
            ViewBag.Message = "Short herd summary";



            List<AnimalShortModel> animalList = new List<AnimalShortModel>();

            animalList.Add(new AnimalShortModel { AnimalNumber = "123", Gender = "male", DateOfBirth = DateTime.Today.Date, HerdNumber = "312" });
            animalList.Add(new AnimalShortModel { AnimalNumber = "123", Gender = "male", DateOfBirth = DateTime.Today, HerdNumber = "312" });
            animalList.Add(new AnimalShortModel { AnimalNumber = "123", Gender = "male", DateOfBirth = DateTime.Today, HerdNumber = "312" });
            animalList.Add(new AnimalShortModel { AnimalNumber = "123", Gender = "male", DateOfBirth = DateTime.Today, HerdNumber = "312" });

            return View(animalList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
