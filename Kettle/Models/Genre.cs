using System.Text.Json.Serialization;

namespace Kettle
{
    public class Genre
    {
        [JsonConstructor]
        public Genre(string id, string description) =>
            (Id, Description) = (id, description);

        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("description")]
        public string Description { get; }
    }
}