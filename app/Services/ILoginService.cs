using App.Results;

namespace App.Services
{
    public interface ILoginService
    {
        Task<Result> Login(string username, string password);
        Task Logout();
    }
}
