using WfhTracker.Shared.Models;

namespace WfhTracker.Client.Services;

public class EntryService(IHttpService http)
{
    public async Task<List<Entry>> GetEntriesAsync()
    {
        return await http.GetAsync<List<Entry>>("api/entries") ?? [];
    }

    public async Task<Entry?> GetEntryAsync(Guid id)
    {
        return await http.GetAsync<Entry>($"api/entries/{id}");
    }

    public async Task<Entry?> CreateEntryAsync(Entry entry)
    {
        return await http.PostAsync<Entry, Entry>("api/entries", entry);
    }

    public async Task<Entry?> UpdateEntryAsync(Guid id, Entry entry)
    {
        return await http.PutAsync<Entry, Entry>($"api/entries/{id}", entry);
    }

    public async Task<bool> DeleteEntryAsync(Guid id)
    {
        return await http.DeleteAsync($"api/entries/{id}");
    }
}
