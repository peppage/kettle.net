using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kettle.Internal
{
    public class AppNews
    {
        [JsonConstructor]
        public AppNews(uint appId, IReadOnlyList<News> newsItems, int count) =>
            (AppId, NewsItems, Count) = (appId, newsItems, count);

        [JsonPropertyName("appid")]
        public uint AppId { get; }

        [JsonPropertyName("count")]
        public int Count { get; }

        [JsonPropertyName("newsitems")]
        public IReadOnlyList<News> NewsItems { get; }
    }
}