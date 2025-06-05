using StarWarsGeeks.Business.Models;
using StarWarsGeeks.Business.Repository;
using StarWarsGeeks.Common;

namespace StarWarsGeeks.Business.Service;
public class PlanetService : IPlanetService
{
    private readonly IPlanetRepository planetRepository = null!;

    public PlanetService(IPlanetRepository planetRepository)
    {
        this.planetRepository = planetRepository;
    }

    public PlanetService()
    {
        // This constructor is for mocking purposes only.
    }

    public async Task<Result<List<Planet>>> GetAllPlanetsAsync()
    {
        List<Planet> result = await planetRepository.GetAllPlanetsAsync();

        return result is null
            ? Result<List<Planet>>.Failure(Error.RecordNotFound("No planets found."))
            : Result<List<Planet>>.Success(result);
    }

    public async Task<Result<Planet>> GetPlanetAsync(string name)
    {
        Planet? result = await planetRepository.GetPlanetByName(name);

        return result is null
            ? Result<Planet>.Failure(Error.RecordNotFound($"Planet with name '{name}' not found."))
            : Result<Planet>.Success(result);
    }
}
