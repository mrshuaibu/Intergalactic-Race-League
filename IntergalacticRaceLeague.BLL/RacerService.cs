using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticRaceLeague.DAL;
using IntergalacticRaceLeague.Models;

namespace IntergalacticRaceLeague.BLL
{
    public class RacerService
    {
        private readonly RacerRepository _racerRepository;

        public RacerService(RacerRepository racerRepository)
        {
            _racerRepository = racerRepository;
        }

        public List<Racer> GetAllRacers()
        {
            return _racerRepository.GetAllRacers();
        }

        public Racer GetRacerById(int racerId)
        {
            return _racerRepository.GetRacerById(racerId);
        }

        public void AddRacer(Racer racer)
        {
            Console.WriteLine($"Registering racer: {racer.Name}");
            _racerRepository.AddRacer(racer);
        }

        public void UpdateRacer(Racer racer)
        {
            _racerRepository.UpdateRacer(racer);
        }

        public void DeleteRacer(int racerId)
        {
            _racerRepository.DeleteRacer(racerId);
        }
    }
}
