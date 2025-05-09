using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticRaceLeague.Models
{
    public class RaceResult
    {
        public int RaceResultId { get; set; }

        public string RaceName { get; set; }

        public int Position { get; set; }

        public int TournamentId { get; set; }

        public Tournament? Tournament { get; set; }

        public ICollection<Racer> Racers { get; set; } = new List<Racer>();

        public List<int> SelectedRacersIds { get; set; } = new List<int>();
    }
}
