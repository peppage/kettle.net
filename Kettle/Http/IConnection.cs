using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kettle
{
    /// <summary>
    /// A connection for making HTTP requests against an API.
    /// </summary>
    public interface IConnection
    {
        /// <summary>
        /// Steam API dev key
        /// </summary>
        string ApiKey { get; }

        /// <summary>
        /// Base address for the Steam API
        /// </summary>
        Uri BaseApiAddress { get; }

        /// <summary>
        /// Base address for the Steam store API
        /// </summary>
        Uri BaseStoreAddress { get; }

        /// <summary>
        /// Performs an async HTTP GET request against the Steam API
        /// </summary>
        /// <typeparam name="T">the type to map the response to</typeparam>
        /// <param name="uri">URI endpoint to send request to</param>
        /// <param name="parameters">Querystring parameters for the request</param>
        /// <returns>The server response, see <seealso cref="IResponse"/></returns>
        Task<IApiResponse<T>> GetApiAsync<T>(Uri uri, IDictionary<string, string> parameters);

        /// <summary>
        /// Performs an async HTTP GET request against the Steam Store API
        /// </summary>
        /// <typeparam name="T">the type to map the response to</typeparam>
        /// <param name="uri">URI endpoint to send request to</param>
        /// <param name="parameters">Querystring parameters for the request</param>
        /// <returns>The server response, see <seealso cref="IResponse"/></returns>
        Task<IApiResponse<T>> GetStoreAsync<T>(Uri uri, IDictionary<string, string>? parameters);

        /// <summary>
        /// Sets the timeout between the connection and the server
        /// </summary>
        /// <param name="timeout">How long to wait</param>
        void SetRequestTimeout(TimeSpan timeout);
    }
}