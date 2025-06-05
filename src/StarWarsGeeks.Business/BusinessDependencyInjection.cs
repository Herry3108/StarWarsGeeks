using Microsoft.Extensions.DependencyInjection;
using StarWarsGeeks.Business.Service;

public static class BusinessDependencyInjection
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        _ = services.AddScoped<IPersonService, PersonService>();
        _ = services.AddScoped<IPlanetService, PlanetService>();

        return services;
    }
}
