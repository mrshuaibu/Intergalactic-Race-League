using System.Collections.Generic;
using System.Linq;
using IntergalacticRaceLeague.BLL;
using IntergalacticRaceLeague.DAL;
using IntergalacticRaceLeague.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntergalacticRaceLeague.Controllers
{
    public class RacerController : Controller
    {
        private readonly RacerService _racerService;
        private readonly VehicleService _vehicleService;
        private readonly TournamentService _tournamentService;

        public RacerController(RacerService racerService, VehicleService vehicleService, TournamentService tournamentService)
        {
            _racerService = racerService;
            _vehicleService = vehicleService;
            _tournamentService = tournamentService;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<Racer> racers = _racerService.GetAllRacers();
            return View(racers);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddRacer()
        {
            ViewBag.Vehicles = _vehicleService.GetAllVehicles();
            ViewBag.Tournaments = _tournamentService.GetAllTournaments();

            return View(new Racer());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddRacer(Racer racer)
        {
            if (ModelState.IsValid)
            {
                racer.Vehicle = _vehicleService.GetVehicleById(racer.VehicleId);

                racer.Tournaments = _tournamentService.GetAllTournaments()
                    .Where(t => racer.SelectedTournamentIds.Contains(t.TournamentId))
                    .ToList();

                _racerService.AddRacer(racer);

                return RedirectToAction("Index");
            }

            ViewBag.Vehicles = _vehicleService.GetAllVehicles();
            ViewBag.Tournaments = _tournamentService.GetAllTournaments();
            return View(racer);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditRacer(int id)
        {
            Racer? racer = _racerService.GetAllRacers().FirstOrDefault(r => r.RacerId == id);
            if (racer == null)
            {
                return NotFound();
            }

            ViewBag.Vehicles = _vehicleService.GetAllVehicles();
            ViewBag.Tournaments = _tournamentService.GetAllTournaments();

            return View(racer);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditRacer(Racer racer)
        {
            if (ModelState.IsValid)
            {
                _racerService.UpdateRacer(racer);
                return RedirectToAction("Index");
            }

            ViewBag.Vehicles = _vehicleService.GetAllVehicles();
            ViewBag.Tournaments = _tournamentService.GetAllTournaments();

            return View(racer);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public IActionResult ViewProfile(int id)
        {
            Racer racer = _racerService.GetRacerById(id);

            if (racer == null)
            {
                return NotFound();
            }

            if (racer.Tournaments == null || !racer.Tournaments.Any())
            {
                racer.Tournaments = _tournamentService.GetAllTournaments()
                    .Where(t => racer.SelectedTournamentIds.Contains(t.TournamentId))
                    .ToList();
            }

            return View(racer);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult DeleteRacer(int id)
        {
            Racer? racer = _racerService.GetRacerById(id);
            if (racer == null)
            {
                return NotFound();
            }

            return View(racer);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteRacerConfirmed(int id)
        {
            Racer? racer = _racerService.GetRacerById(id);
            if (racer == null)
            {
                return NotFound();
            }

            _racerService.DeleteRacer(id);

            return RedirectToAction("Index");
        }
    }
}
