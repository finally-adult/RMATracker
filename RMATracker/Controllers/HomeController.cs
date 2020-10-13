using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RMATracker.Interfaces;
using RMATracker.Models;
using RMATracker.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;

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
            var model = new ActiveViewModel();
            model.RMAs = repository.GetAllRMAs().Where(r => r.DateReceived == null);
            model.Parts = new SelectList(repository.GetAllParts(), "Id", "Description");
            return View(model);
        }

        public IActionResult Historical()
        {
            var model = repository.GetAllRMAs().Where(r => r.DateReceived != null);
            return View(model);
        }

        public IActionResult Inventory()
        {
            ViewBag.PartId = new SelectList(repository.GetAllParts(), "Id", "Description");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRMA(ActiveViewModel data)
        {
            var serialNumber = repository.GetSerialNumberById(data.SerialId);

            repository.AddRMA(data.RMA);
            repository.Commit();
            // move logic to repository
            serialNumber.RMAId = data.RMA.Id;
            repository.Commit();

            return RedirectToAction("Active");
        }

        public IActionResult UpdateRMA(ActiveViewModel vm)
        {
            // update RMA fields
            repository.UpdateRMA(vm.RMA);
            repository.Commit();

            // update Serial Number fields?

            return vm.RMA.DateReceived != null ? RedirectToAction("Historical") : RedirectToAction("Active");
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
