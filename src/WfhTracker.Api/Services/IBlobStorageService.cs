namespace WfhTracker.Api.Services
{
    public interface IBlobStorageService
    {
        Task<T?> ReadJsonAsync<T>(string blobName);

        Task WriteJsonAsync<T>(string blobName, T data);
    }
}
