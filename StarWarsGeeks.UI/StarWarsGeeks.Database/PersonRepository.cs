using Microsoft.EntityFrameworkCore;
using StarWarsGeeks.Business.Models;
using StarWarsGeeks.Business.Repository;
using StarWarsGeeks.Database.Context;

namespace StarWarsGeeks.Database;
public class PersonRepository : IPersonRepository
{
    private readonly SwapiDbContext swapiDbContext;

    public PersonRepository(SwapiDbContext swapiDbContext)
    {
        this.swapiDbContext = swapiDbContext;
    }

    public async Task<List<Person>> GetAllPeopleAsync()
    {
        return await swapiDbContext.People.ToListAsync() ?? [];
    }

    public Task<Person?> GetPersonByName(string name)
    {
        return swapiDbContext.People.FirstOrDefaultAsync(person => person.Name.Equals(name));
    }
}
