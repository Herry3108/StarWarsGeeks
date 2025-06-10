using Microsoft.EntityFrameworkCore;
using StarWarsGeeks.Business.Models;
using StarWarsGeeks.Business.Repository;
using StarWarsGeeks.Database.Context;

namespace StarWarsGeeks.Database;
public class PersonRepository : IPersonRepository
{
    private readonly StarWarsDbContext starWarsDbContext;

    public PersonRepository(StarWarsDbContext starWarsDbContext)
    {
        this.starWarsDbContext = starWarsDbContext;
    }

    public async Task<List<Person>> GetAllPeopleAsync()
    {
        return await starWarsDbContext.People.ToListAsync() ?? [];
    }

    public async Task<Person?> GetPersonByName(string name)
    {
        var result = await starWarsDbContext.People.FirstOrDefaultAsync(person => person.Name.Equals(name));

        if (result is null)
        {
            return result;
        }

        result.TimesSearched = result.TimesSearched + 1;
        await starWarsDbContext.SaveChangesAsync();

        return result;
    }
}
