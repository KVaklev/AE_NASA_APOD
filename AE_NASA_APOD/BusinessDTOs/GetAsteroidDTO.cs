using System.ComponentModel.DataAnnotations;

namespace BusinessDTOs
{
    public class GetAsteroidDTO
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "The{0} must be between {1} and {2} characters long.")]
        public string Name { get; set; }
        public double EstimatedMaxDiameter { get; set; }
        public string VelocityKmH { get; set; }
        public string DistanceKm { get; set; }

    }
}