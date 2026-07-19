using WfhTracker.Api.Services;
using WfhTracker.Shared.Models;

namespace WfhTracker.Api.Repositories;

public class BlobEntryRepository(IBlobStorageService blobStorage) : IEntryRepository
{
    // Note: No validations are performed (such as checking for duplicate entries).
    public async Task<IEnumerable<Entry>> GetAllAsync()
    {
        return await LoadEntriesAsync();
    }

    public async Task AddAsync(Entry entry)
    {
        var entries = (await LoadEntriesAsync()).ToList();

        entries.Add(entry);

        await blobStorage.WriteJsonAsync("test-user.json", entries);
    }

    public async Task<Entry?> GetAsync(Guid id)
    {
        var entries = (await LoadEntriesAsync()).ToList();

        return entries.Find(x => x.Id == id);
    }

    public async Task UpdateAsync(Entry entry)
    {
        var entries = (await LoadEntriesAsync()).ToList();

        var index = entries.FindIndex(x => x.Id == entry.Id);
        if (index >= 0)
        {
            entries[index] = entry;
            await blobStorage.WriteJsonAsync("test-user.json", entries);
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var entries = (await LoadEntriesAsync()).ToList();

        entries.RemoveAll(x => x.Id == id);

        await blobStorage.WriteJsonAsync("test-user.json", entries);
    }

    private async Task<IEnumerable<Entry>> LoadEntriesAsync()
    {
        return (await blobStorage.ReadJsonAsync<List<Entry>>("test-user.json"))
            ?? [];
    }
}
