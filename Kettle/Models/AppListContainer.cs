using System.Text.Json.Serialization;

namespace Kettle.Internal
{
    public class AppListContainer
    {
        [JsonConstructor]
        public AppListContainer(AppList applist) => AppList = applist;

        [JsonPropertyName("applist")]
        public AppList AppList { get; }
    }
}