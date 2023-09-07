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
                EstimatedMaxDiameter = asteroid.EstimatedDiameter.Kilometers.MaximumDiameter,                
            };
        }

        public GetAPODDTO Map(APOD apod)
        {
            return new GetAPODDTO
            {
                Title = apod.Title,
                Url = apod.Url,
            };
        }
        
    }
}