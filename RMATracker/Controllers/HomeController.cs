using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RMATracker.Interfaces;
using RMATracker.Models;
using System.Diagnostics;

namespace RMATracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRMATrackerRepository repository;

        public HomeController(ILogger<HomeController> logger, IRMATrackerRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Active()
        {
            // this will become an AJAX call from the JS to load child rows
            var model = repository.GetAllRMAs();
            return View(model);
        }

        public IActionResult Historical()
        {
            return View();
        }

        public IActionResult Inventory()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddRMA()
        {
            return View();
        }

        public IActionResult UpdateRMA()
        {
            return View();
        }

        public IActionResult AddPart()
        {
            return View();
        }

        public IActionResult UpdatePart()
        {
            return View();
        }

        public IActionResult AddSerialNumber()
        {
            return View();
        }

        public IActionResult UpdateSerialNumber()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
