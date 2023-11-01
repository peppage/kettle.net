using System.Text.Json.Serialization;

namespace Kettle.Internal
{
    public class NewsContainer
    {
        [JsonConstructor]
        public NewsContainer(AppNews appNews) => AppNews = appNews;

        [JsonPropertyName("appnews")]
        public AppNews AppNews { get; }
    }
}