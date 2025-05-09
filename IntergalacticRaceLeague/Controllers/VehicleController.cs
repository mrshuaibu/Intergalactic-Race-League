using IntergalacticRaceLeague.BLL;
using IntergalacticRaceLeague.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IntergalacticRaceLeague.Controllers
{
    public class VehicleController : Controller
    {
        private readonly VehicleService _vehicleService;

        public VehicleController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<Vehicle> vehicles = _vehicleService.GetAllVehicles();
            return View(vehicles);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddVehicle()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddVehicle(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _vehicleService.AddVehicle(vehicle);
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditVehicle(int id)
        {
            Vehicle vehicle = _vehicleService.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditVehicle(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _vehicleService.UpdateVehicle(vehicle);
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult DeleteVehicle(int id)
        {
            Vehicle vehicle = _vehicleService.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteVehicleConfirmed(int id)
        {
            Vehicle vehicle = _vehicleService.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _vehicleService.DeleteVehicle(id);
            return RedirectToAction("Index");
        }
    }
}
