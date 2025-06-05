using StarWarsGeeks.Business.Models;

namespace StarWarsGeeks.Business.Repository;
public interface IPersonRepository
{
    Task<Person?> GetPersonByName(string name);
    Task<List<Person>> GetAllPeopleAsync();
}
