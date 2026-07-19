using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using WfhTracker.Api.Models;

namespace WfhTracker.Api.Services;

public interface IBlobStorageService
{
    Task<T?> ReadJsonAsync<T>(string blobName);

    Task WriteJsonAsync<T>(string blobName, T data);
}

public class BlobStorageService : IBlobStorageService
{
    private readonly BlobContainerClient _container;

    public BlobStorageService(IOptions<StorageOptions> options)
    {
        var serviceClient = new BlobServiceClient(
            options.Value.ConnectionString);

        _container = serviceClient.GetBlobContainerClient(
            options.Value.ContainerName);
    }

    public async Task<T?> ReadJsonAsync<T>(string blobName)
    {
        BlobClient blobClient = _container.GetBlobClient(blobName);

        if (!await blobClient.ExistsAsync())
        {
            return default;
        }

        BlobDownloadInfo download = await blobClient.DownloadAsync();

        using var stream = download.Content;
        return await JsonSerializer.DeserializeAsync<T>(stream);

    }

    public async Task WriteJsonAsync<T>(string blobName, T data)
    {
        BlobClient blobClient = _container.GetBlobClient(blobName);

        string json = JsonSerializer.Serialize(data);

        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

        await blobClient.UploadAsync(stream, overwrite: true);
    }
}
