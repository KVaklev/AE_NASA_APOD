using System.Text.Json.Serialization;

namespace DataAccessModels.Models
{
    public class Asteroid
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [JsonPropertyName("nasa_jpl_url")]
        public string NasaJplUrl { get; set; }

        [JsonPropertyName("absolute_magnitude_h")]
        public double AbsoluteMagnitude { get; set; }

        [JsonPropertyName("estimated_diameter")]
        public EstimatedDiameter EstimatedDiameter { get; set; }

        [JsonPropertyName("is_potentially_hazardous_asteroid")]
        public bool Hazardous { get; set; }

        [JsonPropertyName("close_approach_data")]
        public CloseAproachData[] CloseApproachData { get; set; }
    }

    public class NeoResult
    {
        [JsonPropertyName("near_earth_objects")]
        public List<Asteroid> NearEarthObjects { get; set; }
    }

    public class EstimatedDiameter
    {
        public RangeValues Kilometers { get; set; }
        public RangeValues Meters { get; set; }
        public RangeValues Miles { get; set; }
        public RangeValues Feet { get; set; }
    }

    public class RangeValues
    {
        [JsonPropertyName("estimated_diameter_min")]
        public double MinimumDiameter { get; set; }

        [JsonPropertyName("estimated_diameter_max")]
        public double MaximumDiameter { get; set; }
    }

    public class CloseAproachData
    {
        [JsonPropertyName("close_approach_date")]
        public string FirstApproachDate { get; set; }

        [JsonPropertyName("relative_velocity")]
        public VelocityData RelativeVelocity { get; set; }
    }

    public class VelocityData
    {
        [JsonPropertyName("kilometers_per_hour")]
        public string KilometersPerHour { get; set; }
    }

}
