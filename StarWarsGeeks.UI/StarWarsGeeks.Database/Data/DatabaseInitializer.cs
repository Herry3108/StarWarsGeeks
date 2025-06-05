using StarWarsGeeks.Business.Models;
using StarWarsGeeks.Database.Context;

namespace StarWarsGeeks.Database.Data;
public class DatabaseInitializer
{
    private readonly SwapiTestDataService swapiTestDataService;
    private readonly SwapiDbContext swapiDbContext;

    public DatabaseInitializer(SwapiDbContext context, SwapiTestDataService swapiTestDataService)
    {
        swapiDbContext = context;
        this.swapiTestDataService = swapiTestDataService;
    }

    public async Task InitializeAsync()
    {
        await SeedPeopleAsync();
        await SeedPlanetsAsync();
    }

    private async Task SeedPlanetsAsync()
    {
        List<Planet> planets = await swapiTestDataService.GetPlanetsAsync();
        swapiDbContext.Planets.AddRange(planets);
        _ = await swapiDbContext.SaveChangesAsync();
    }

    private async Task SeedPeopleAsync()
    {
        List<Person> people = await swapiTestDataService.GetPeopleAsync();
        swapiDbContext.People.AddRange(people);
        _ = await swapiDbContext.SaveChangesAsync();
    }
}
