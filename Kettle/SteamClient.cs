using Kettle.Internal;
using System;

namespace Kettle
{
    /// <summary>
    /// A client for the Steam API. You can read more <see href="https://wiki.teamfortress.com/wiki/WebAPI"/>
    /// </summary>
    public class SteamClient : ISteamClient
    {
        /// <summary>
        /// The default URL for the Steam API
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1075:URIs should not be hardcoded", Justification = "Not changing, default for Valve")]
        public static readonly Uri SteamApiUrl = new Uri("https://api.steampowered.com/");

        /// <summary>
        /// The default URL for the Steam store API
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1075:URIs should not be hardcoded", Justification = "Not changing, default for Valve")]
        public static readonly Uri SteamStoreApiUrl = new Uri("https://store.steampowered.com/");

        /// <summary>
        /// Create a new instance of the Steam API client that doesn't need an API key.
        /// </summary>
        public SteamClient() : this(new Connection())
        {
        }

        /// <summary>
        /// Create a new instance of the Steam API client that doesn't need an
        /// API key but you want to specify your own <see cref="IHttpClient"/>
        /// </summary>
        /// <param name="httpClient">Client to make requests through</param>
        public SteamClient(IHttpClient httpClient) : this(new Connection(httpClient))
        {
        }

        /// <summary>
        /// Create a new instance of the Steam API, can use
        /// endpoints that require an API Key.
        /// </summary>
        /// <remarks>Get an API key here <see href="https://steamcommunity.com/dev/apikey"/>. KEEP IT SECRET</remarks>
        /// <param name="apiKey">Steam Web API developer key</param>
        public SteamClient(string apiKey) : this(new Connection(apiKey))
        {
        }

        /// <summary>
        /// Create a new instance of the Steam API, can use
        /// endpoints that require an API Key. Also while using your own <see cref="IHttpClient"/>
        /// </summary>
        /// <remarks>Get an API key here <see href="https://steamcommunity.com/dev/apikey"/>. KEEP IT SECRET</remarks>
        /// <param name="apiKey">Steam Web API developer key</param>
        /// <param name="httpClient">Client to make requests through</param>
        public SteamClient(string apiKey, IHttpClient httpClient) : this(new Connection(apiKey, httpClient))
        {
        }

        /// <summary>
        /// Create a new instance of the Steam API.
        /// </summary>
        /// <param name="connection">Connection used for making requests</param>
        public SteamClient(IConnection connection)
        {
            Ensure.ArgumentNotNull(connection, nameof(connection));

            Connection = connection;
            AppsClient = new AppsClient(Connection);
            NewsClient = new NewsClient(Connection);
            StoreClient = new StoreClient(Connection);
        }

        /// <inheritdoc/>
        public string ApiKey => Connection.ApiKey;

        /// <inheritdoc/>
        public Uri BaseApiAddress => Connection.BaseApiAddress;

        /// <inheritdoc/>
        public Uri BaseStoreAddress => Connection.BaseStoreAddress;

        /// <inheritdoc/>
        public IConnection Connection { get; }

        /// <inheritdoc/>
        public IStoreClient StoreClient { get; }

        /// <inheritdoc/>
        public IAppsClient AppsClient { get; }

        /// <inheritdoc/>
        public INewsClient NewsClient { get; }

        /// <inheritdoc/>
        public void SetRequestTimeout(TimeSpan timeout)
        {
            Connection.SetRequestTimeout(timeout);
        }
    }
}