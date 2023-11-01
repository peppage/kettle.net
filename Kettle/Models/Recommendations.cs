using System.Text.Json.Serialization;

namespace Kettle
{
    /// <summary>
    /// Number shown on store page next to all reviews score
    /// </summary>
    public class Recommendations
    {
        [JsonConstructor]
        public Recommendations(int total) => (Total) = (total);

        /// <summary>
        /// The total amount of recommendations
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; }
    }
}