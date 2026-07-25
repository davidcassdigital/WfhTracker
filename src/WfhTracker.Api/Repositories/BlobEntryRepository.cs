using WfhTracker.Api.Services;
using WfhTracker.Shared.Models;

namespace WfhTracker.Api.Repositories;

public class BlobEntryRepository(IBlobStorageService blobStorage) : IEntryRepository
{
    // Note: No validations are performed (such as checking for duplicate entries, or negaative values).
    public async Task<IEnumerable<Entry>> GetAllAsync(string userId)
    {
        return await LoadEntriesAsync(userId);
    }

    public async Task AddAsync(string userId, Entry entry)
    {
        var entries = (await LoadEntriesAsync(userId)).ToList();

        entries.Add(entry);

        await blobStorage.WriteJsonAsync($"{userId}.json", entries);
    }

    public async Task<Entry?> GetAsync(string userId, Guid id)
    {
        var entries = (await LoadEntriesAsync(userId)).ToList();

        return entries.Find(x => x.Id == id);
    }

    public async Task UpdateAsync(string userId, Entry entry)
    {
        var entries = (await LoadEntriesAsync(userId)).ToList();

        var index = entries.FindIndex(x => x.Id == entry.Id);
        if (index >= 0)
        {
            entries[index] = entry;
            await blobStorage.WriteJsonAsync($"{userId}.json", entries);
        }
    }

    public async Task DeleteAsync(string userId, Guid id)
    {
        var entries = (await LoadEntriesAsync(userId)).ToList();

        entries.RemoveAll(x => x.Id == id);

        await blobStorage.WriteJsonAsync($"{userId}.json", entries);
    }

    private async Task<IEnumerable<Entry>> LoadEntriesAsync(string userId)
    {
        return (await blobStorage.ReadJsonAsync<List<Entry>>($"{userId}.json"))
            ?? [];
    }
}
