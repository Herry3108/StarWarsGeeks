using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StarWarsGeeks.Business.Repository;
using StarWarsGeeks.Database;
using StarWarsGeeks.Database.Context;
using StarWarsGeeks.Database.Data;

public static class DBDependencyInjection
{
    public static IServiceCollection AddDatabaseRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        IServiceCollection serviceCollection = services.AddDbContext<StarWarsDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));

        _ = services.AddTransient<StarWarsTestDataService>();
        _ = services.AddScoped<IPersonRepository, PersonRepository>();
        _ = services.AddScoped<IPlanetRepository, PlanetRepository>();

        //Seed Test data from CSV file  
        StarWarsDbContext swapiDbContext = services.BuildServiceProvider().GetRequiredService<StarWarsDbContext>();
        StarWarsTestDataService swapiTestDataService = services.BuildServiceProvider().GetRequiredService<StarWarsTestDataService>();
        _ = Task.Run(async () => await InitializeDatabaseAsync(swapiDbContext, swapiTestDataService));

        return services;
    }

    private static async Task InitializeDatabaseAsync(StarWarsDbContext swapiDbContext, StarWarsTestDataService swapiTestDataService)
    {
        DatabaseInitializer databaseInitializer = new(swapiDbContext, swapiTestDataService);
        await databaseInitializer.InitializeAsync();
    }
}
