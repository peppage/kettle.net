using System;
using System.Text.Json.Serialization;

//TODO: missing feed_type, tags

namespace Kettle
{
    public class News
    {
        [JsonConstructor]
        public News(string author, string contents, uint epoch, bool externalUrl, string feedLabel, string feedName, string gid, string title, string url) =>
            (Author, Contents, Epoch, ExternalUrl, FeedLabel, FeedName, Gid, Title, Url) = (author, contents, epoch, externalUrl, feedLabel, feedName, gid, title, url);

        /// <summary>
        /// Who wrote the news item. It's optional.
        /// </summary>
        [JsonPropertyName("author")]
        public string Author { get; }

        [JsonPropertyName("contents")]
        public string Contents { get; }

        /// <summary>
        /// Helper for converting <see cref="Epoch"/> to a <see cref="DateTime"/>.
        /// </summary>
        [JsonIgnore]
        public DateTime Date => DateTimeOffset.FromUnixTimeSeconds(Epoch).DateTime;

        /// <summary>
        /// Unix time in seconds when the news was released.
        /// <!-- Must be set to public for JSON deserialize -->
        /// </summary>
        [JsonPropertyName("date")]
        public uint Epoch { get; }

        /// <summary>
        /// If the news is from an external site.
        /// </summary>
        [JsonPropertyName("is_external_url")]
        public bool ExternalUrl { get; }

        [JsonPropertyName("feedlabel")]
        public string FeedLabel { get; }

        [JsonPropertyName("feedname")]
        public string FeedName { get; }

        /// <summary>
        /// Unique id for the news item.
        /// </summary>
        [JsonPropertyName("gid")]
        public string Gid { get; }

        /// <summary>
        /// Title of the news item.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; }

        /// <summary>
        /// Url to read the news item in a browser.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; }
    }
}