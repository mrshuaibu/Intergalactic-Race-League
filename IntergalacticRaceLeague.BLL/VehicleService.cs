using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticRaceLeague.DAL;
using IntergalacticRaceLeague.Models;

namespace IntergalacticRaceLeague.BLL
{
    public class VehicleService
    {
        private readonly VehicleRepository _vehicleRepository;

        public VehicleService(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicleRepository.GetAllVehicles();
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            return _vehicleRepository.GetVehicleById(vehicleId);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicleRepository.AddVehicle(vehicle);
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            _vehicleRepository.UpdateVehicle(vehicle);
        }

        public void DeleteVehicle(int vehicleId)
        {
            _vehicleRepository.DeleteVehicle(vehicleId);
        }
    }
}
