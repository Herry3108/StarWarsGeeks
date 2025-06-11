using Microsoft.AspNetCore.Mvc;
using StarWarsGeeks.Business.Models;
using StarWarsGeeks.Business.Service;
using StarWarsGeeks.Common;

namespace StarWarsGeeks.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StarWarsController : ControllerBase
{
    private readonly IPersonService personService;
    private readonly IPlanetService planetService;

    public StarWarsController(IPersonService personService, IPlanetService planetService)
    {
        this.personService = personService;
        this.planetService = planetService;
    }

    [HttpGet("people/{name}")]
    public async Task<IActionResult> GetPerson(string name)
    {
        Result<Person> result = await personService.GetPersonAsync(name);

        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error.Message);
    }

    [HttpGet("people")]
    public async Task<IActionResult> GetAllPeople()
    {
        Result<List<Person>> result = await personService.GetAllPeopleAsync();

        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error.Message);
    }

    [HttpGet("planets/{name}")]
    public async Task<IActionResult> GetPlanet(string name)
    {
        Result<Planet> result = await planetService.GetPlanetAsync(name);

        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error.Message);
    }

    [HttpGet("planets")]
    public async Task<IActionResult> GetAllPlanets()
    {
        Result<List<Planet>> result = await planetService.GetAllPlanetsAsync();

        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error.Message);
    }
}
