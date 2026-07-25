using WfhTracker.Shared.Models;

namespace WfhTracker.Api.Repositories;

public interface IEntryRepository
{
    Task<IEnumerable<Entry>> GetAllAsync(string userId);

    Task<Entry?> GetAsync(string userId, Guid id);

    Task AddAsync(string userId, Entry entry);

    Task UpdateAsync(string userId, Entry entry);

    Task DeleteAsync(string userId, Guid id);
}
