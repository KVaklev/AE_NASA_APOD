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
                Copyright = asteroid.Copyright,
                Title = asteroid.Title,
                DateTime = asteroid.DateTime,
                Explanation = asteroid.Explanation,

            };
        }
    }
}