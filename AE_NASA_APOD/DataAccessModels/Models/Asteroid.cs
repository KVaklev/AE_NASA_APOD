using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessModels.Models
{
    public class Asteroid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NasaJplUrl { get; set; }
        public double AbsoluteMagnitude { get; set; }
        public double EstimatedMaxDiameter { get; set; }
        public bool Hazardous { get; set; }
        public string CloseApproachDate { get; set; }
        public string VelocityKmH { get; set; }
        public string DistanceKm { get; set; }
    }
}
