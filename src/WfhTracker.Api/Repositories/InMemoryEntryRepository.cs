using WfhTracker.Shared.Models;

namespace WfhTracker.Api.Repositories;

public class InMemoryEntryRepository : IEntryRepository
{
    public Task AddAsync(Entry entry)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Entry>> GetAllAsync()
    {
        var entries = new List<Entry>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Date = DateOnly.FromDateTime(DateTime.Today),
                HoursWorked = 8,
                Notes = "Worked from home"
            }
        };

        return Task.FromResult<IEnumerable<Entry>>(entries);
    }

    public Task<Entry?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Entry entry)
    {
        throw new NotImplementedException();
    }
}
