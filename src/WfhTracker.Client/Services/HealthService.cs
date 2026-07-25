namespace WfhTracker.Client.Services
{
    public class HealthService(IHttpService http)
    {
        public async Task<string> GetStatusAsync()
        {
            return await http.GetAsync<string>("api/health") ?? string.Empty;
        }
    }
}
