using App.Entities;
using App.Extensions;
using App.Repositories;
using App.Results;

namespace App.Services
{
    public class CityService : ICityService
    {
        public readonly ICityRepository _repository;

        public CityService(ICityRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<City>>> ListCities()
        {
            var cities = await _repository.List();
            return cities.AsResult();
        }
    }
}
