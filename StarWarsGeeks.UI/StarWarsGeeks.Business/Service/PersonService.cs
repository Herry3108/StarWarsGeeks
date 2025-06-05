using StarWarsGeeks.Business.Models;
using StarWarsGeeks.Business.Repository;
using StarWarsGeeks.Common;

namespace StarWarsGeeks.Business.Service;
public class PersonService : IPersonService
{
    private readonly IPersonRepository personRepository = null!;

    public PersonService(IPersonRepository personRepository)
    {
        this.personRepository = personRepository;
    }

    public PersonService()
    {
        // This constructor is for mocking purposes only.
    }

    public async Task<Result<List<Person>>> GetAllPeopleAsync()
    {
        List<Person> result = await personRepository.GetAllPeopleAsync();

        return result is null
            ? Result<List<Person>>.Failure(Error.RecordNotFound("No people found."))
            : Result<List<Person>>.Success(result);
    }

    public async Task<Result<Person>> GetPersonAsync(string name)
    {
        Person? result = await personRepository.GetPersonByName(name);

        return result is null
            ? Result<Person>.Failure(Error.RecordNotFound($"Person with name '{name}' not found."))
            : Result<Person>.Success(result);
    }
}
