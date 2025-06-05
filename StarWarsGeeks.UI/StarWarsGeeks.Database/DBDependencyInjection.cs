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
        IServiceCollection serviceCollection = services.AddDbContext<SwapiDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));

        _ = services.AddTransient<SwapiTestDataService>();
        _ = services.AddScoped<IPersonRepository, PersonRepository>();
        _ = services.AddScoped<IPlanetRepository, PlanetRepository>();

        //Seed Test data from CSV file  
        SwapiDbContext swapiDbContext = services.BuildServiceProvider().GetRequiredService<SwapiDbContext>();
        SwapiTestDataService swapiTestDataService = services.BuildServiceProvider().GetRequiredService<SwapiTestDataService>();
        _ = Task.Run(async () => await InitializeDatabaseAsync(swapiDbContext, swapiTestDataService));

        return services;
    }

    private static async Task InitializeDatabaseAsync(SwapiDbContext swapiDbContext, SwapiTestDataService swapiTestDataService)
    {
        DatabaseInitializer databaseInitializer = new(swapiDbContext, swapiTestDataService);
        await databaseInitializer.InitializeAsync();
    }
}
