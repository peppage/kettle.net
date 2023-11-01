using Kettle.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kettle
{
    /// <summary>
    /// A client for Steam's news API
    /// </summary>
    public interface INewsClient
    {
        /// <summary>
        /// Returns the latest news of a game specified by its id.
        /// </summary>
        /// <param name="id">The game app id.</param>
        /// <param name="maxLength">Max length of content field.</param>
        /// <param name="endDate">News before this time.</param>
        /// <param name="count">Max number of items to get.</param>
        /// <param name="feeds">List of feeds to return news for.</param>
        /// <exception cref="SteamAppException">Thrown when there is no response</exception>
        /// <returns>A list of news items</returns>
        /// <remarks>
        /// <seealso href="https://developer.valvesoftware.com/wiki/Steam_Web_API#GetNewsForApp_.28v0002.29"/><br></br>
        /// <seealso href="https://wiki.teamfortress.com/wiki/WebAPI/GetNewsForApp"/>
        /// </remarks>
        Task<AppNews> GetNewsAsync(uint id, int maxLength = 0, DateTime? endDate = null, int count = 0, IEnumerable<string>? feeds = null);
    }
}