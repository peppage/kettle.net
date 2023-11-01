using System.Text.Json.Serialization;

namespace Kettle
{
    /// <summary>
    /// Scoring from <seealso href="https://www.metacritic.com/"/>.
    /// </summary>
    public class Metacritic
    {
        [JsonConstructor]
        public Metacritic(int score, string url) =>
            (Score, Url) = (score, url);

        /// <summary>
        /// Current score of the app from 0 to 100.
        /// </summary>
        [JsonPropertyName("score")]
        public int Score { get; }

        /// <summary>
        /// Url to see the reviews for the app on Metacritic.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; }
    }
}