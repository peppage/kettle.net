using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kettle
{
    /// <summary>
    /// A client for Steam's ISteamApps API.
    /// </summary>
    public interface IAppsClient
    {
        /// <summary>
        /// A list of all apps on the Steam store
        /// </summary>
        /// <returns>A list of all Apps</returns>
        /// <remarks><seealso href="https://wiki.teamfortress.com/wiki/WebAPI/GetAppList"/></remarks>
        Task<IReadOnlyList<App>> GetAppListAsync();
    }
}