using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RMATracker.Interfaces;
using RMATracker.Models;
using System;
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
            return View();
        }

        public IActionResult Historical()
        {
            // AJAX Call
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

        [HttpPost]
        public IActionResult AddRMA(RMA rma)
        {
            rma.DateSent = DateTime.Now;
            repository.AddRMA(rma);
            repository.Commit();
            return RedirectToAction("Active");
        }

        public IActionResult UpdateRMA()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateRMA(RMA rma)
        {
            return RedirectToAction("Active");
        }

        public IActionResult AddPart()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPart(Part part)
        {
            repository.AddPart(part);
            repository.Commit();
            return RedirectToAction("Inventory");
        }

        public IActionResult UpdatePart()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdatePart(Part part)
        {
            return RedirectToAction("Inventory");
        }

        public IActionResult AddSerialNumber()
        {
            ViewBag.PartId = new SelectList(repository.GetAllParts(), "Id", "Description");
            return View();
        }

        [HttpPost]
        public IActionResult AddSerialNumber(SerialNumber serialNumber)
        {
            repository.AddSerialNumber(serialNumber);
            repository.Commit();
            return RedirectToAction("Inventory");
        }

        public IActionResult UpdateSerialNumber()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateSerialNumber(SerialNumber serialNumber)
        {
            return RedirectToAction("Inventory");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
