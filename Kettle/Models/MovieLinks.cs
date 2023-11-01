using Kettle.Internal;
using System.Text.Json.Serialization;

namespace Kettle
{
    /// <summary>
    /// Webm links for a <see cref="Movie"/>
    /// </summary>
    [JsonConverter(typeof(MovieLinksJsonConverter))]
    public class MovieLinks
    {
        /// <summary>
        /// URL to lower resolution video
        /// </summary>
        [JsonPropertyName("480")]
        public string Resolution480 { get; internal set; } = string.Empty;

        /// <summary>
        /// URL to maximum resolution video
        /// </summary>
        [JsonPropertyName("max")]
        public string ResolutionMax { get; internal set; } = string.Empty;
    }
}