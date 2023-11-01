using Kettle.Helpers;
using Kettle.Internal;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kettle
{
    /// <inheritdoc cref="IStoreClient"/>
    public class StoreClient : ApiClient, IStoreClient
    {
        /// <summary>
        /// Setup a new Steam Store API client
        /// </summary>
        /// <param name="connection">An API connection</param>
        public StoreClient(IConnection connection) : base(connection)
        {
        }

        /// <inheritdoc/>
        public async Task<AppData> AppDetailsAsync(uint appId)
        {
            IApiResponse<AppDetails> resp;

            try
            {
                resp = await Connection.GetStoreAsync<AppDetails>(ApiUrls.GetAppDetails(appId), null);
            }
            catch (HtmlResponseException ex)
            {
                throw new SteamAppException(appId, ex);
            }
            catch (JsonException ex)
            {
                throw new SteamAppException(appId, "Failed to parse JSON", ex);
            }
            catch (Exception ex)
            {
                throw new SteamAppException(appId, "Failed", ex);
            }

            if (resp.Body == null)
            {
                throw new SteamAppException(appId, "Nothing returned", new NullReferenceException());
            }

            if (!resp.Body.Success)
            {
                throw new NoSuccessException(appId, "Success returned as false", System.Net.HttpStatusCode.OK);
            }

            return resp.Body.Data;
        }
    }
}