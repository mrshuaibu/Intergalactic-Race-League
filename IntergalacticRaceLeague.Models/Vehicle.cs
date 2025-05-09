using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticRaceLeague.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        public string Name { get; set; }

        public Racer? Racer { get; set; }
    }
}
