using BuberDinner.Application.Common.Interfaces.Perisistence;
using BuberDinner.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}