using DataAccessModels.Models;

namespace AE_NASA_APOD.Models
{
    public class AsteroidViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NasaJplUrl { get; set; }
        public string FirstApproachDate { get; set; }
        public double AbsoluteMagnitude { get; set; }
        public double MaximumDiameter { get; set; }
        public bool Hazardous { get; set; }
        public string Velocity { get; set; }
    }
}
