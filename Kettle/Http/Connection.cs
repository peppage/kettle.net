using Kettle.Internal;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Kettle
{
    /// <summary>
    /// A connection for making HTTP requests against URI endpoints.
    /// </summary>
    public class Connection : IConnection
    {
        private static readonly Uri _defaultSteamApiUrl = SteamClient.SteamApiUrl;
        private static readonly Uri _defaultSteamStoreApiUrl = SteamClient.SteamStoreApiUrl;
        private readonly IHttpClient _httpClient;
        private readonly JsonHttpPipeline _jsonHttpPipeline;

        /// <summary>
        /// Create a new connection instance used to make requests to the Steam API
        /// </summary>
        public Connection() : this("", new HttpClientAdapter(), _defaultSteamApiUrl, _defaultSteamStoreApiUrl)
        {
        }

        /// <summary>
        /// Create a new connection instance used to make requests to the Steam API
        /// </summary>
        /// <param name="httpClient">The client used to execute requests</param>
        public Connection(IHttpClient httpClient) : this("", httpClient, _defaultSteamApiUrl, _defaultSteamStoreApiUrl)
        {
        }

        /// <summary>
        /// Create a new connection instance used to make requests to the Steam API
        /// </summary>
        /// <param name="apiKey">Steam API dev key</param>
        public Connection(string apiKey) : this(apiKey, new HttpClientAdapter(), _defaultSteamApiUrl, _defaultSteamStoreApiUrl)
        {
        }

        /// <summary>
        /// Create a new connection instance used to make requests to the Steam API
        /// </summary>
        /// <param name="apiKey">Steam API dev key</param>
        /// <param name="httpClient">The client used to execute requests</param>
        public Connection(string apiKey, IHttpClient httpClient) : this(apiKey, httpClient, _defaultSteamApiUrl, _defaultSteamStoreApiUrl)
        {
        }

        /// <summary>
        /// Create a new connection instance used to make requests to the Steam API
        /// </summary>
        /// <param name="apiKey">Steam API dev key</param>
        /// <param name="httpClient">The client used to execute requests</param>
        /// <param name="baseApiAddress">The address to point this client to for the API</param>
        /// <param name="baseStoreAddress">The address to point this client to for the Store API</param>
        /// <exception cref="ArgumentException"></exception>
        public Connection(string apiKey, IHttpClient httpClient, Uri baseApiAddress, Uri baseStoreAddress)
        {
            Ensure.ArgumentNotNull(baseApiAddress, nameof(baseApiAddress));
            Ensure.ArgumentNotNull(baseStoreAddress, nameof(baseStoreAddress));
            Ensure.ArgumentNotNull(httpClient, nameof(httpClient));

            if (!baseApiAddress.IsAbsoluteUri)
            {
                throw new ArgumentException($"The base address '{baseApiAddress}' must be an absolute URI", nameof(baseApiAddress));
            }

            if (!baseStoreAddress.IsAbsoluteUri)
            {
                throw new ArgumentException($"The base address '{baseStoreAddress}' must be an absolute URI", nameof(baseStoreAddress));
            }

            BaseApiAddress = baseApiAddress;
            BaseStoreAddress = baseStoreAddress;
            _httpClient = httpClient;
            ApiKey = apiKey;
            _jsonHttpPipeline = new JsonHttpPipeline();
        }

        /// <inheritdoc/>
        public string ApiKey { get; }

        /// <inheritdoc/>
        public Uri BaseApiAddress { get; }

        /// <inheritdoc/>
        public Uri BaseStoreAddress { get; }

        /// <inheritdoc/>
        public Task<IApiResponse<T>> GetApiAsync<T>(Uri uri, IDictionary<string, string> parameters) => GetAsync<T>(BaseApiAddress, uri, parameters);

        /// <inheritdoc/>
        public Task<IApiResponse<T>> GetStoreAsync<T>(Uri uri, IDictionary<string, string>? parameters) => GetAsync<T>(BaseStoreAddress, uri, parameters);

        /// <inheritdoc/>
        public void SetRequestTimeout(TimeSpan timeout)
        {
            _httpClient.SetRequestTimeout(timeout);
        }

        private Task<IApiResponse<T>> GetAsync<T>(Uri baseAddress, Uri uri, IDictionary<string, string>? parameters)
        {
            Ensure.ArgumentNotNull(uri, nameof(uri));

            var request = new Request(baseAddress, uri.ApplyParameters(parameters), HttpMethod.Get);

            return RunAsync<T>(request, CancellationToken.None);
        }

        private async Task<IApiResponse<T>> RunAsync<T>(IRequest request, CancellationToken cancellationToken)
        {
            var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            return _jsonHttpPipeline.DeserializeResponse<T>(response);
        }
    }
}