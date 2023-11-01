using System;

namespace Kettle
{
    /// <summary>
    /// Class for retrieving Steam API URLs
    /// </summary>
    public static class ApiUrls
    {
        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all apps on Steam.
        /// </summary>
        /// <returns></returns>
        public static Uri GetAppList()
        {
            return "ISteamApps/GetAppList/v2/".FormatUri();
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns news for an app.
        /// </summary>
        /// <param name="appId">The id of the app</param>
        /// <returns></returns>
        public static Uri GetNews(uint appId)
        {
            return "ISteamNews/GetNewsForApp/v0002?appid={0}".FormatUri(appId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns details for an app.
        /// </summary>
        /// <param name="appId">The id of the app</param>
        /// <returns></returns>
        public static Uri GetAppDetails(uint appId)
        {
            return "api/appdetails/?appids={0}".FormatUri(appId);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns reviews for an app.
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static Uri GetReviews(uint appId)
        {
            return "appreviews/{0}".FormatUri(appId);
        }
    }
}