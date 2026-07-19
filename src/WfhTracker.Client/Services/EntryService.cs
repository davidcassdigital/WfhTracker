using WfhTracker.Shared.Models;

namespace WfhTracker.Client.Services
{
    public class EntryService(IHttpService http)
    {
        public async Task<List<Entry>> GetEntriesAsync()
        {
            return await http.GetAsync<List<Entry>>("api/entries") ?? [];
        }
    }
}
