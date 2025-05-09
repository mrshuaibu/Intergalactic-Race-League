using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticRaceLeague.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }

        public string TournamentName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public ICollection<Racer> Racers { get; set; } = new List<Racer>();

        public ICollection<RaceResult> RaceResults { get; set; } = new List<RaceResult>();
    }
}
