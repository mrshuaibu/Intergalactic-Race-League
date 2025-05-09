using System.Collections.Generic;
using System.Linq;
using IntergalacticRaceLeague.DAL;
using IntergalacticRaceLeague.Models;
using Microsoft.EntityFrameworkCore;

namespace IntergalacticRaceLeague.Repositories
{
    public class RaceResultRepository
    {
        private readonly IntergalacticRaceLeagueDbContext _context;

        public RaceResultRepository(IntergalacticRaceLeagueDbContext context)
        {
            _context = context;
        }

        public List<RaceResult> GetAllRaceResults()
        {
            return _context.RaceResults
                .Include(rr => rr.Racers) 
                .Include(rr => rr.Tournament)
                .ToList();
        }

        public RaceResult? GetRaceResultById(int id)
        {
            return _context.RaceResults
                .Include(rr => rr.Racers)
                .Include(rr => rr.Tournament)
                .FirstOrDefault(rr => rr.RaceResultId == id);
        }

        public void AddRaceResult(RaceResult raceResult)
        {
            _context.RaceResults.Add(raceResult);
            _context.SaveChanges();
        }

        public void UpdateRaceResult(RaceResult raceResult)
        {
            RaceResult? existingRaceResult = _context.RaceResults.Find(raceResult.RaceResultId);
            if (existingRaceResult != null) {

                existingRaceResult.RaceName = raceResult.RaceName;
                existingRaceResult.Position = raceResult.Position;
                existingRaceResult.TournamentId = raceResult.TournamentId;
                existingRaceResult.Racers = raceResult.Racers;

                _context.RaceResults.Update(raceResult);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Race result not found for update");
            }
        }

        public void DeleteRaceResult(int id)
        {
            var raceResult = _context.RaceResults.Find(id);
            if (raceResult != null)
            {
                _context.RaceResults.Remove(raceResult);
                _context.SaveChanges();
            }
        }
    }
}
