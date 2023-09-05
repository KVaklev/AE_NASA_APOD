using BusinessDTOs;
using DataAccessModels.Models;

namespace Mapper
{
    public class ModelMapper
    {
        public GetAsteroidDTO Map(Asteroid asteroid)
        {
            return new GetAsteroidDTO
            {
                Name = asteroid.Name,
                EstimatedMaxDiameter = asteroid.EstimatedMaxDiameter,
                VelocityKmH = asteroid.VelocityKmH,
                DistanceKm = asteroid.DistanceKm,

            };
        }
    }
}