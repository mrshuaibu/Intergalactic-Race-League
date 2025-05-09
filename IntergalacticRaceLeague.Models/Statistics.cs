namespace IntergalacticRaceLeague.Models
{
    public class Statistics
    {
        public int StatisticsId { get; set; }

        public int TotalRacers { get; set; }

        public int TotalTournaments { get; set; }

        public int TotalVehicles { get; set; }

        public List<Racer> TopRacers { get; set; } = new List<Racer>();

        public List<Tournament> TopTournaments { get; set; } = new List<Tournament>();
    }
}
