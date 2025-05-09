using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticRaceLeague.Models
{
    public class Racer
    {
        public int RacerId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Country { get; set; }

        public int VehicleId { get; set; }

        public Vehicle? Vehicle { get; set; }

        public ICollection<RaceResult> RaceResults { get; set; } = new List<RaceResult>();

        public ICollection<Tournament> Tournaments { get; set; } = new List<Tournament>();

        public List<int> SelectedTournamentIds { get; set; } = new List<int>();
    }
}
