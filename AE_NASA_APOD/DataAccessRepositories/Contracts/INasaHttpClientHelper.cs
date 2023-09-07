using DataAccessModels.Models;

namespace DataAccessRepositories.Contracts
{
    public interface INasaHttpClientHelper
    {
        public Task<HttpResponseMessage> GetAllAsteriodsResponse();

        public Task<HttpResponseMessage> GetPictureOfTheDay();

        public Task<HttpResponseMessage> GetAPODByDate(DateTime? date);
    }
}
