using BusinessDTOs;
using DataAccessModels.Models;

namespace Mapper
{
    public class ModelMapper
    {
        public Asteroid Map(GetAsteroidDTO getAsteroidDTO)
        {
            return new Asteroid
            {
                Copyright = getAsteroidDTO.Copyright,
                Title = getAsteroidDTO.Title,
                DateTime = getAsteroidDTO.DateTime,
            };
        }
    }
}