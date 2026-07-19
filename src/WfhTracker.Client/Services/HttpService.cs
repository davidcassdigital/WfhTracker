using System.Text;
using System.Text.Json;

namespace WfhTracker.Client.Services
{
    public interface IHttpService
    {
        Task<T?> GetAsync<T>(string uri, CancellationToken cancellationToken = default);
        Task<TResponse?> PostAsync<TRequest, TResponse>(string uri, TRequest content, CancellationToken cancellationToken = default);
        Task<T?> PostAsync<T>(string uri, T content, CancellationToken cancellationToken = default);
        Task<T?> PutAsync<TRequest, T>(string uri, TRequest content, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(string uri, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken = default);
    }

    public class HttpService(HttpClient client) : IHttpService
    {
        private readonly HttpClient _client = client ?? throw new ArgumentNullException(nameof(client));
        private readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web);


        public async Task<T?> GetAsync<T>(string uri, CancellationToken cancellationToken = default)
        {
            using var resp = await _client.GetAsync(uri, cancellationToken).ConfigureAwait(false);
            resp.EnsureSuccessStatusCode();
            return await DeserializeAsync<T>(resp, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string uri, TRequest content, CancellationToken cancellationToken = default)
        {
            using var req = CreateJsonRequest(HttpMethod.Post, uri, content);
            using var resp = await _client.SendAsync(req, cancellationToken).ConfigureAwait(false);
            resp.EnsureSuccessStatusCode();
            return await DeserializeAsync<TResponse>(resp, cancellationToken).ConfigureAwait(false);
        }

        public async Task<T?> PostAsync<T>(string uri, T content, CancellationToken cancellationToken = default)
        {
            return await PostAsync<T, T>(uri, content, cancellationToken).ConfigureAwait(false);
        }

        public async Task<T?> PutAsync<TRequest, T>(string uri, TRequest content, CancellationToken cancellationToken = default)
        {
            using var req = CreateJsonRequest(HttpMethod.Put, uri, content);
            using var resp = await _client.SendAsync(req, cancellationToken).ConfigureAwait(false);
            resp.EnsureSuccessStatusCode();
            return await DeserializeAsync<T>(resp, cancellationToken).ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(string uri, CancellationToken cancellationToken = default)
        {
            using var resp = await _client.DeleteAsync(uri, cancellationToken).ConfigureAwait(false);
            return resp.IsSuccessStatusCode;
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
        {
            return _client.SendAsync(request, cancellationToken);
        }

        private HttpRequestMessage CreateJsonRequest<TContent>(HttpMethod method, string uri, TContent content)
        {
            var json = JsonSerializer.Serialize(content, _jsonOptions);
            var req = new HttpRequestMessage(method, uri)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            return req;
        }

        private async Task<T?> DeserializeAsync<T>(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            if (response.Content == null)
                return default;

            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
            if (stream == null || stream.Length == 0)
                return default;

            return await JsonSerializer.DeserializeAsync<T>(stream, _jsonOptions, cancellationToken).ConfigureAwait(false);
        }
    }
}