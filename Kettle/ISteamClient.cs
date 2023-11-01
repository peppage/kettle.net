using System;

namespace Kettle
{
    public interface ISteamClient
    {
        /// <summary>
        /// Steam developer API key.
        /// </summary>
        /// <remarks>
        /// Get a key from <seealso href="https://steamcommunity.com/dev/apikey"/>. KEEP IT SECRET.
        /// </remarks>
        string ApiKey { get; }

        /// <summary>
        /// Base address of the Steam API. This defaults to https://api.steampowered.com/
        /// </summary>
        Uri BaseApiAddress { get; }

        /// <summary>
        /// Base address of Steam Store API. This defaults to https://store.steampowered.com/
        /// </summary>
        Uri BaseStoreAddress { get; }

        /// <summary>
        /// Client connection to make API requests with.
        /// </summary>
        IConnection Connection { get; }

        /// <summary>
        /// Access the Steam Store API.
        /// </summary>
        IStoreClient StoreClient { get; }

        /// <summary>
        /// Access Steam apps information.
        /// </summary>
        IAppsClient AppsClient { get; }

        /// <summary>
        /// Access Steam news information.
        /// </summary>
        INewsClient NewsClient { get; }

        /// <summary>
        /// Set the connection timeout between the client and server.
        /// </summary>
        /// <param name="timeout">How long to wait</param>
        void SetRequestTimeout(TimeSpan timeout);
    }
}