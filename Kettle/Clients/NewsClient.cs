using Kettle.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kettle
{
    /// <inheritdoc cref="INewsClient"/>
    public class NewsClient : ApiClient, INewsClient
    {
        /// <summary>
        /// Setup a new news API client
        /// </summary>
        /// <param name="connection">An API connection</param>
        public NewsClient(IConnection connection) : base(connection)
        {
        }

        /// <inheritdoc/>
        public async Task<AppNews> GetNewsAsync(uint id, int maxLength = 0, DateTime? endDate = null, int count = 0, IEnumerable<string>? feeds = null)
        {
            var endDateParam = endDate.HasValue ? ((DateTimeOffset)endDate.Value).ToUnixTimeSeconds().ToString() : "";
            var feedNameParam = feeds != null ? string.Join(",", feeds) : "";

            var parameters = new Dictionary<string, string>
            {
                { "maxlength", maxLength == 0 ? "" : maxLength.ToString() },
                { "count", count == 0 ? "" : count.ToString() },
                { "enddate",  endDateParam},
                { "feedname", feedNameParam},
            };

            var resp = await Connection.GetApiAsync<NewsContainer>(ApiUrls.GetNews(id), parameters).ConfigureAwait(false);

            if (resp == null || resp.Body == null)
            {
                throw new SteamAppException(id, "Get News had no response", System.Net.HttpStatusCode.Forbidden);
            }

            return resp.Body.AppNews;
        }
    }
}