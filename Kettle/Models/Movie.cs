using System.Text.Json.Serialization;

namespace Kettle
{
    /// <summary>
    /// Videos about the app
    /// </summary>
    public class Movie
    {
        [JsonConstructor]
        public Movie(int id, string name, string thumbnail, MovieLinks webm, MovieLinks mp4, bool highlight)
        {
            Id = id;
            Name = name;
            Thumbnail = thumbnail;
            Webm = webm;
            Mp4 = mp4;
            Highlight = highlight;
        }

        /// <summary>
        /// Unique id of the movie
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; }

        /// <summary>
        /// Name of the movie
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; }

        /// <summary>
        /// URL to thumbnail of the movie
        /// </summary>

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; }

        /// <summary>
        /// Links to webm format of the video
        /// </summary>
        [JsonPropertyName("webm")]
        public MovieLinks Webm { get; }

        /// <summary>
        /// Liniks to the mp4 format of the video
        /// </summary>
        [JsonPropertyName("mp4")]
        public MovieLinks Mp4 { get; }

        /// <summary>
        /// If the movie is shown first on the store page
        /// </summary>
        [JsonPropertyName("highlight")]
        public bool Highlight { get; }
    }
}