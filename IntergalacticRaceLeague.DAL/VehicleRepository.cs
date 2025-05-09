using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticRaceLeague.Models;

namespace IntergalacticRaceLeague.DAL
{
    public class VehicleRepository
    {
        private readonly IntergalacticRaceLeagueDbContext _context;

        public VehicleRepository(IntergalacticRaceLeagueDbContext context)
        {
            _context = context;
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _context.Vehicles.ToList();
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            return _context.Vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            Vehicle? existingVehicle = _context.Vehicles.Find(vehicle.VehicleId);
            if (existingVehicle != null)
            {
                existingVehicle.Name = vehicle.Name;
                _context.Vehicles.Update(existingVehicle);
                _context.SaveChanges();
            }
        }

        public void DeleteVehicle(int vehicleId)
        {
            Vehicle? vehicle = _context.Vehicles.Find(vehicleId);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
            }
        }
    }
}
