using System.Text.Json.Serialization;

namespace Kettle
{
    public class Requirements
    {
        [JsonConstructor]
        public Requirements(string minimum, string recommended) =>
            (Minimum, Recommended) = (minimum, recommended);

        [JsonPropertyName("minimum")]
        public string Minimum { get; }

        [JsonPropertyName("recommended")]
        public string Recommended { get; }
    }
}