using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticRaceLeague.Models;
using Microsoft.EntityFrameworkCore;

namespace IntergalacticRaceLeague.DAL
{
    public class RacerRepository
    {
        private readonly IntergalacticRaceLeagueDbContext _context;

        public RacerRepository(IntergalacticRaceLeagueDbContext context)
        {
            _context = context;
        }

        public List<Racer> GetAllRacers()
        {
            return _context.Racers.ToList();
        }

        public Racer GetRacerById(int id)
        {
            return _context.Racers
                .Include(r => r.Vehicle)  
                .Include(r => r.Tournaments) 
                .FirstOrDefault(r => r.RacerId == id);
        }

        public void AddRacer(Racer racer)
        {
            try
            {
                _context.Racers.Add(racer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving racer: {ex.Message}");
                throw;
            }
        }

        public void UpdateRacer(Racer racer)
        {
            Racer? existingRacer = _context.Racers.Find(racer.RacerId);
            if (existingRacer != null)
            {
                Console.WriteLine($"Updating racer {racer.RacerId} in database.");

                existingRacer.Name = racer.Name;
                existingRacer.Age = racer.Age;
                existingRacer.Country = racer.Country;

                _context.Racers.Update(existingRacer);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Racer not found for update.");
            }
        }

        public void DeleteRacer(int racerId)
        {
            Racer? racer = _context.Racers.Find(racerId);
            if (racer != null)
            {
                _context.Racers.Remove(racer);
                _context.SaveChanges();
            }
        }
    }
}
