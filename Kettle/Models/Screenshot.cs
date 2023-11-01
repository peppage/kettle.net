using System.Text.Json.Serialization;

namespace Kettle
{
    public class Screenshot
    {
        [JsonConstructor]
        public Screenshot(int id, string pathThumbnail, string pathFull) =>
            (Id, PathThumbnail, PathFull) = (id, pathThumbnail, pathFull);

        /// <summary>
        /// Order of screenshot on page
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; }

        /// <summary>
        /// URL to lower resolution image
        /// </summary>
        [JsonPropertyName("path_thumbnail")]
        public string PathThumbnail { get; }

        /// <summary>
        /// URL to maximum resolution image
        /// </summary>
        [JsonPropertyName("path_full")]
        public string PathFull { get; }
    }
}