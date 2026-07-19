using WfhTracker.Shared.Models;

namespace WfhTracker.Api.Repositories;

public interface IEntryRepository
{
    Task<IEnumerable<Entry>> GetAllAsync();
    Task<Entry?> GetAsync(Guid id);
    Task AddAsync(Entry entry);
    Task UpdateAsync(Entry entry);
    Task DeleteAsync(Guid id);
}
