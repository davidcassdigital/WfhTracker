namespace WfhTracker.Client.Services
{
    public class HealthService(HttpClient http)
    {
        public async Task<string> GetStatusAsync()
        {
            return await http.GetStringAsync("api/health");
        }
    }
}
