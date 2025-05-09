using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticRaceLeague.Models;

namespace IntergalacticRaceLeague.DAL
{
    public class StatisticsRepository
    {
        private readonly IntergalacticRaceLeagueDbContext _context;

        public StatisticsRepository(IntergalacticRaceLeagueDbContext context)
        {
            _context = context;
        }

        public Statistics GetStatistics()
        {
            return new Statistics
            {
                TotalRacers = _context.Racers.Count(),
                TotalTournaments = _context.Tournaments.Count(),
                TotalVehicles = _context.Vehicles.Count(),
                TopRacers = _context.Racers.OrderByDescending(r => r.RaceResults.Count).Take(5).ToList(),
                TopTournaments = _context.Tournaments.OrderByDescending(t => t.RaceResults.Count).Take(5).ToList()
            };
        }
    }
}
