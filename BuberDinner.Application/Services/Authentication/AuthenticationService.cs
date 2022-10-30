using BuberDinner.Application.Authentication;
using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Perisistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {      
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new DuplicateEmailException();
        }
        var user = new User 
        { 
            FirstName = firstName, 
            LastName = lastName, 
            Email = email, 
            Password = password 
        };
        
        _userRepository.Add(user);
        return new AuthenticationResult(
            user);
    }

    public AuthenticationResult Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("Invalid login");
        }
        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }

        return new AuthenticationResult(
           user);
    }
}
