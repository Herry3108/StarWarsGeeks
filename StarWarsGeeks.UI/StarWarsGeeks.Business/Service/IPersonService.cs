using StarWarsGeeks.Business.Models;
using StarWarsGeeks.Common;

namespace StarWarsGeeks.Business.Service;
public interface IPersonService
{
    Task<Result<Person>> GetPersonAsync(string name);
    Task<Result<List<Person>>> GetAllPeopleAsync();
}
