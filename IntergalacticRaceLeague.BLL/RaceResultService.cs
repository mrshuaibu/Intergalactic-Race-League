using System.Collections.Generic;
using IntergalacticRaceLeague.Models;
using IntergalacticRaceLeague.Repositories;

namespace IntergalacticRaceLeague.BLL
{
    public class RaceResultService
    {
        private readonly RaceResultRepository _raceResultRepository;

        public RaceResultService(RaceResultRepository raceResultRepository)
        {
            _raceResultRepository = raceResultRepository;
        }

        public List<RaceResult> GetAllRaceResults()
        {
            return _raceResultRepository.GetAllRaceResults();
        }

        public RaceResult? GetRaceResultById(int id)
        {
            return _raceResultRepository.GetRaceResultById(id);
        }

        public void AddRaceResult(RaceResult raceResult)
        {
            _raceResultRepository.AddRaceResult(raceResult);
        }

        public void UpdateRaceResult(RaceResult raceResult)
        {
            _raceResultRepository.UpdateRaceResult(raceResult);
        }

        public void DeleteRaceResult(int id)
        {
            _raceResultRepository.DeleteRaceResult(id);
        }
    }
}
