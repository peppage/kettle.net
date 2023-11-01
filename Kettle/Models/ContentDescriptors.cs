using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kettle
{
    /// <summary>
    /// Age related warnings about the content of the app
    /// </summary>
    public class ContentDescriptors
    {
        /// <summary>
        /// Create a new instance of the ContentDescriptors
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="notes"></param>
        [JsonConstructor]
        public ContentDescriptors(IReadOnlyList<int> ids, string notes) =>
            (Ids, Notes) = (ids, notes);

        /// <summary>
        /// Ids of specific content descriptors related to app
        /// </summary>
        [JsonPropertyName("ids")]
        public IReadOnlyList<int> Ids { get; }

        /// <summary>
        /// Specific notes about the content descriptors
        /// </summary>
        [JsonPropertyName("notes")]
        public string Notes { get; }
    }
}