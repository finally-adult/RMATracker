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
            var parts = repository.GetAllParts()
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = $"{p.PartNumber}: {p.Description}"
                });

            var model = new ActiveViewModel
            {
                Parts = new SelectList(repository.GetAllParts(), "Id", "Description")
            };

            return View(model);
        }

        public IActionResult Active()
        {
            var parts = repository.GetAllParts()
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = $"{p.PartNumber}: {p.Description}"
                });

            var model = new ActiveViewModel
            {
                RMAs = repository.GetAllRMAs().Where(r => r.DateReceived is null),
                Parts = new SelectList(repository.GetAllParts(), "Id", "Description")
            };
            return View(model);
        }

        public IActionResult Historical()
        {
            var model = repository.GetAllRMAs().Where(r => r.DateReceived is not null);
            return View(model);
        }

        public IActionResult Inventory()
        {
            var model = new InventoryViewModel
            {
                Parts = repository.GetAllParts()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddRMA(ActiveViewModel data)
        {
            repository.AddRMA(data.RMA);
            repository.Commit();

            return RedirectToAction("Active");
        }

        [HttpPost]
        public IActionResult UpdateRMA(ActiveViewModel vm)
        {
            if (vm.NewSerialNumber is not null)
            {
                vm.RMA.SerialNumberReceived = vm.NewSerialNumber;
            }
            if (vm.RMA.DateReceived is not null)
            {
                var part = repository.GetPart(vm.RMA.PartId);
                part.QuantityOnHand += 1;
                part.QuantityOutForRepair -= 1;
            }

            repository.UpdateRMA(vm.RMA);
            repository.Commit();

            return vm.RMA.DateReceived is not null ? RedirectToAction("Historical") : RedirectToAction("Active");
        }

        [HttpPost]
        public IActionResult DeleteRMA(ActiveViewModel vm)
        {
            repository.DeleteRMA(vm.RMA.Id);
            repository.Commit();
            return RedirectToAction("Active");
        }

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
            repository.UpdatePart(part);
            repository.Commit();
            return RedirectToAction("Inventory");
        }

        [HttpPost]
        public IActionResult DeletePart(int id)
        {
            repository.DeletePart(id);
            repository.Commit();
            return RedirectToAction("Inventory");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
