using System.Security.Claims;
using App.Exceptions;
using App.Repositories;
using App.Results;
using App.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace App.Services
{
    public class LoginService : ILoginService
    {
        public readonly IHttpContextAccessor _acessor;
        public readonly IUserRepository _repository;

        public LoginService(IUserRepository repository, IHttpContextAccessor acessor)
        {
            _repository = repository;
            _acessor = acessor;
        }

        public async Task<Result> Login(string username, string password)
        {
            var user = await _repository.GetByUsername(username);

            if (user == null)
            {
                return new IncorrectUserOrPasswordException();
            }

            if (!Password.Verify(password, user.Password))
            {
                return new IncorrectUserOrPasswordException();
            }

            var claims = new List<Claim> { new(ClaimTypes.Sid, user.Id.ToString()) };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await _acessor.HttpContext!.SignInAsync(new ClaimsPrincipal(identity));

            return new();
        }

        public async Task Logout()
        {
            await _acessor.HttpContext!.SignOutAsync();
        }
    }
}
