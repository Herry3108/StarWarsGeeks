using Microsoft.AspNetCore.Mvc;
using Moq;
using StarWarsGeeks.Api.Controllers;
using StarWarsGeeks.Business.Models;
using StarWarsGeeks.Business.Service;
using StarWarsGeeks.Common;

namespace StarWarsGeeks.Tests;
public class StarWarsControllerTests
{
    private readonly Mock<IPersonService> _personServiceMock;
    private readonly Mock<IPlanetService> _planetServiceMock;
    private readonly StarWarsController _starWarsController;

    public StarWarsControllerTests()
    {
        _personServiceMock = new Mock<IPersonService>();
        _planetServiceMock = new Mock<IPlanetService>();
        _starWarsController = new StarWarsController(_personServiceMock.Object, _planetServiceMock.Object);
    }

    [Fact]
    public async Task GetPerson_IfSuccess_ReturnsPerson()
    {
        // Arrange
        string personName = "Luke Skywalker";
        Person expectedPerson = StarWarsControllerTestData.GetPersonTestData().First();
        Result<Person> expectedResult = Result<Person>.Success(expectedPerson);

        _ = _personServiceMock.Setup(setup => setup.GetPersonAsync(personName)).ReturnsAsync(expectedResult);

        // Act
        IActionResult result = await _starWarsController.GetPerson(personName);

        // Assert
        OkObjectResult resultOk = Assert.IsType<OkObjectResult>(result);
        Person resultPerson = Assert.IsType<Person>(resultOk.Value);
        Assert.Equal(expectedPerson.Name, resultPerson.Name);
        Assert.Equal(expectedPerson.Height, resultPerson.Height);
        Assert.Equal(expectedPerson.Mass, resultPerson.Mass);
    }

    [Fact]
    public async Task GetPerson_IfFailure_ReturnsNotFound()
    {
        // Arrange
        string personName = "NonExistentPerson";
        Result<Person> expectedResult = Result<Person>.Failure(new Error("PersonNotFound", $"Person with name '{personName}' not found"));

        _ = _personServiceMock.Setup(setup => setup.GetPersonAsync(personName)).ReturnsAsync(expectedResult);

        // Act
        IActionResult result = await _starWarsController.GetPerson(personName);

        // Assert
        NotFoundObjectResult resultNotFound = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal(resultNotFound.Value, expectedResult.Error.Message);
    }

    [Fact]
    public async Task GetAllPeople_IfSuccess_ReturnsAllPeople()
    {
        // Arrange
        List<Person> expectedPeople = StarWarsControllerTestData.GetPersonTestData().ToList();
        Result<List<Person>> expectedResult = Result<List<Person>>.Success(expectedPeople);

        _ = _personServiceMock.Setup(setup => setup.GetAllPeopleAsync()).ReturnsAsync(expectedResult);

        // Act
        IActionResult result = await _starWarsController.GetAllPeople();

        // Assert
        OkObjectResult resultOk = Assert.IsType<OkObjectResult>(result);
        List<Person> resultPeople = Assert.IsType<List<Person>>(resultOk.Value);
        Assert.Equal(expectedPeople.Count, resultPeople.Count);
        Assert.Equal(expectedPeople.First().Name, resultPeople.First().Name);
    }

    [Fact]
    public async Task GetAllPeople_IfFailure_ReturnsNotFound()
    {
        // Arrange
        Result<List<Person>> expectedResult = Result<List<Person>>.Failure(new Error("PeopleNotFound", "No people found"));

        _ = _personServiceMock.Setup(setup => setup.GetAllPeopleAsync()).ReturnsAsync(expectedResult);

        // Act
        IActionResult result = await _starWarsController.GetAllPeople();

        // Assert
        NotFoundObjectResult resultNotFound = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal(resultNotFound.Value, expectedResult.Error.Message);
    }

    [Fact]
    public async Task GetPlanet_IfSuccess_ReturnsPlanet()
    {
        // Arrange
        string planetName = "Tatooine";
        Planet expectedPlanet = StarWarsControllerTestData.GetPlanetTestData().First();
        Result<Planet> expectedResult = Result<Planet>.Success(expectedPlanet);

        _ = _planetServiceMock.Setup(setup => setup.GetPlanetAsync(planetName)).ReturnsAsync(expectedResult);

        // Act
        IActionResult result = await _starWarsController.GetPlanet(planetName);

        // Assert
        OkObjectResult resultOk = Assert.IsType<OkObjectResult>(result);
        Planet resultPlanet = Assert.IsType<Planet>(resultOk.Value);
        Assert.Equal(expectedPlanet.Name, resultPlanet.Name);
        Assert.Equal(expectedPlanet.Climate, resultPlanet.Climate);
        Assert.Equal(expectedPlanet.Terrain, resultPlanet.Terrain);
    }

    [Fact]
    public async Task GetPlanet_IfFailure_ReturnsNotFound()
    {
        // Arrange
        string planetName = "NonExistentPlanet";
        Result<Planet> expectedResult = Result<Planet>.Failure(new Error("PlanetNotFound", $"Planet with name '{planetName}' not found"));

        _ = _planetServiceMock.Setup(setup => setup.GetPlanetAsync(planetName)).ReturnsAsync(expectedResult);

        // Act
        IActionResult result = await _starWarsController.GetPlanet(planetName);

        // Assert
        NotFoundObjectResult resultNotFound = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal(resultNotFound.Value, expectedResult.Error.Message);
    }

    [Fact]
    public async Task GetAllPlanets_IfSuccess_ReturnsAllPlanets()
    {
        // Arrange
        List<Planet> expectedPlanets = StarWarsControllerTestData.GetPlanetTestData().ToList();
        Result<List<Planet>> expectedResult = Result<List<Planet>>.Success(expectedPlanets);

        _ = _planetServiceMock.Setup(setup => setup.GetAllPlanetsAsync()).ReturnsAsync(expectedResult);

        // Act
        IActionResult result = await _starWarsController.GetAllPlanets();

        // Assert
        OkObjectResult resultOk = Assert.IsType<OkObjectResult>(result);
        List<Planet> resultPlanets = Assert.IsType<List<Planet>>(resultOk.Value);
        Assert.Equal(expectedPlanets.Count, resultPlanets.Count);
        Assert.Equal(expectedPlanets.First().Name, resultPlanets.First().Name);
    }

    [Fact]
    public async Task GetAllPlanets_IfFailure_ReturnsNotFound()
    {
        // Arrange
        Result<List<Planet>> expectedResult = Result<List<Planet>>.Failure(new Error("PlanetsNotFound", "No planets found"));

        _ = _planetServiceMock.Setup(setup => setup.GetAllPlanetsAsync()).ReturnsAsync(expectedResult);

        // Act
        IActionResult result = await _starWarsController.GetAllPlanets();

        // Assert
        NotFoundObjectResult resultNotFound = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal(resultNotFound.Value, expectedResult.Error.Message);
    }
}