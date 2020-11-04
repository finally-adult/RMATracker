using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RMATracker.Interfaces;
using RMATracker.Models;
using RMATracker.ViewModels;
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

        //public IActionResult Active()
        //{
        //    var model = new ActiveViewModel
        //    {
        //        RMAs = repository.GetAllRMAs().Where(r => r.DateReceived == null),
        //        Parts = new SelectList(repository.GetAllParts(), "Id", "Description")
        //    };
        //    return View(model);
        //}

        //public IActionResult Historical()
        //{
        //    var model = repository.GetAllRMAs().Where(r => r.DateReceived != null);
        //    return View(model);
        //}

        //public IActionResult Inventory()
        //{
        //    ViewBag.PartId = new SelectList(repository.GetAllParts(), "Id", "Description");
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddRMA(ActiveViewModel data)
        //{
        //    var serialNumber = repository.GetSerialNumberById(data.SerialId);

        //    repository.AddRMA(data.RMA);
        //    repository.Commit();
        //    // move logic to repository
        //    serialNumber.RMAId = data.RMA.Id;
        //    serialNumber.OutForRepair = true;
        //    repository.Commit();

        //    return RedirectToAction("Active");
        //}

        //[HttpPost]
        //public IActionResult UpdateRMA(ActiveViewModel vm)
        //{
        //    if (vm.NewSerialNumber != null)
        //    {
        //        vm.RMA.SerialNumber.Serial = vm.NewSerialNumber;
        //    }
        //    if (vm.RMA.DateReceived != null)
        //    {
        //        vm.RMA.SerialNumber.OutForRepair = false;
        //    }

        //    repository.UpdateRMA(vm.RMA);
        //    repository.UpdateSerialNumber(vm.RMA.SerialNumber);
        //    repository.Commit();

        //    return vm.RMA.DateReceived != null ? RedirectToAction("Historical") : RedirectToAction("Active");
        //}

        //[HttpPost]
        //public IActionResult DeleteRMA(ActiveViewModel vm)
        //{
        //    repository.DeleteRMA(vm.RMA.Id);
        //    repository.RemoveSerialNumberByRMAId(vm.RMA.Id);
        //    repository.Commit();
        //    return RedirectToAction("Active");
        //}

        [HttpPost]
        public IActionResult AddPart(Part part)
        {
            repository.AddPart(part);
            repository.Commit();
            return RedirectToAction("Inventory");
        }

        [HttpPost]
        public IActionResult UpdatePart(Part part)
        {
            return RedirectToAction("Inventory");
        }

        //[HttpPost]
        //public IActionResult AddSerialNumber(SerialNumber serialNumber)
        //{
        //    repository.AddSerialNumber(serialNumber);
        //    repository.Commit();
        //    return RedirectToAction("Inventory");
        //}

        //[HttpPost]
        //public IActionResult UpdateSerialNumber(SerialNumber serialNumber)
        //{
        //    return RedirectToAction("Inventory");
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
