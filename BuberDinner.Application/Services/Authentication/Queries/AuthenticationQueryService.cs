using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Perisistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        if (user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        return new AuthenticationResult(
           user);
    }
}
