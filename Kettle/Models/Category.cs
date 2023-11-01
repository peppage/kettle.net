using System.Text.Json.Serialization;

namespace Kettle
{
    /// <summary>
    /// App categories that can be used to search for other apps
    /// that have the same category.
    /// </summary>
    public class Category
    {
        [JsonConstructor]
        public Category(int id, string description) =>
            (Id, Description) = (id, description);

        /// <summary>
        /// Unique id of the category
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; }

        /// <summary>
        /// Description of the category
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; }
    }
}