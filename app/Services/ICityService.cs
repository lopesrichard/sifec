using App.Entities;
using App.Results;

namespace App.Services
{
    public interface ICityService
    {
        Task<Result<IEnumerable<City>>> ListCities();
    }
}
