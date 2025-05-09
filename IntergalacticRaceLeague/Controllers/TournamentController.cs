using IntergalacticRaceLeague.BLL;
using IntergalacticRaceLeague.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IntergalacticRaceLeague.Controllers
{
    public class TournamentController : Controller
    {
        private readonly TournamentService _tournamentService;
        private readonly RacerService _racerService;
        private readonly RaceResultService _raceResultService;

        public TournamentController(TournamentService tournamentService, RaceResultService raceResultService, RacerService racerService)
        {
            _racerService = racerService;
            _tournamentService = tournamentService;
            _raceResultService = raceResultService;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<Tournament> tournaments = _tournamentService.GetAllTournaments();
            return View(tournaments);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddTournament()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddTournament(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                _tournamentService.AddTournament(tournament);
                return RedirectToAction("Index");
            }
            return View(tournament);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditTournament(int id)
        {
            Tournament? tournament = _tournamentService.GetTournamentById(id);
            if (tournament == null)
            {
                return NotFound();
            }

            ViewBag.Racers = _racerService.GetAllRacers();

            return View(tournament);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditTournament(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                _tournamentService.UpdateTournament(tournament);

                return RedirectToAction("Index");
            }

            ViewBag.Racers = _racerService.GetAllRacers(); 
            return View(tournament);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult DeleteTournament(int id)
        {
            Tournament? tournament = _tournamentService.GetTournamentById(id);
            if (tournament == null)
            {
                return NotFound();
            }
            return View(tournament);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteTournamentConfirmed(int id)
        {
            Tournament? tournament = _tournamentService.GetTournamentById(id);
            if (tournament == null)
            {
                return NotFound();
            }

            _tournamentService.DeleteTournament(id);
            return RedirectToAction("Index");
        }

        //RACE RESULT
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult RecordRace()
        {
            ViewBag.Racers = _racerService.GetAllRacers();
            ViewBag.Tournaments = _tournamentService.GetAllTournaments();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult RecordRace(RaceResult raceResult)
        {
            if (ModelState.IsValid)
            {
                foreach (var id in raceResult.SelectedRacersIds)
                {
                    Racer racer = _racerService.GetRacerById(id); 
                    if (racer != null)
                    {
                        raceResult.Racers.Add(racer);
                    }
                }

                _raceResultService.AddRaceResult(raceResult);
                return RedirectToAction("Index");
            }

            return View(raceResult);
        }

        [Authorize]
        public IActionResult ViewWinners(int tournamentId)
        {
            List<RaceResult> winners = _raceResultService.GetAllRaceResults()
                                .Where(rr => rr.TournamentId == tournamentId)
                                .OrderBy(rr => rr.Position)
                                .ToList();

            return View(winners);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult DeleteResult(int id)
        {
            RaceResult? raceResult = _raceResultService.GetRaceResultById(id);
            if (raceResult == null)
            {
                return NotFound();
            }
            return View(raceResult);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteResultConfirmed(int id)
        {
            RaceResult? raceResult = _raceResultService.GetRaceResultById(id);
            if (raceResult == null)
            {
                return NotFound();
            }

            _raceResultService.DeleteRaceResult(id);
            return RedirectToAction("Index");
        }
    }
}
