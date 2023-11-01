using Kettle.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kettle
{
    /// <inheritdoc cref="IStoreClient"/>
    public class AppsClient : ApiClient, IAppsClient
    {
        /// <summary>
        /// Setup a new Apps API client
        /// </summary>
        /// <param name="connection">An API connection</param>
        public AppsClient(IConnection connection) : base(connection)
        {
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyList<App>> GetAppListAsync()
        {
            var resp = await Connection.GetApiAsync<AppListContainer>(ApiUrls.GetAppList(), null!).ConfigureAwait(false);
            return resp.Body.AppList.Apps;
        }
    }
}