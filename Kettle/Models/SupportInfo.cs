using System.Text.Json.Serialization;

namespace Kettle
{
    /// <summary>
    /// Contact information for technical support
    /// </summary>
    public class SupportInfo
    {
        /// <summary>
        /// Create a new instance of the SupportInfo.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="email"></param>
        [JsonConstructor]
        public SupportInfo(string url, string email) =>
            (Url, Email) = (url, email);

        /// <summary>
        /// Website where users can get support for the app
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; }

        /// <summary>
        /// Email where users can get support for the app
        /// </summary>

        [JsonPropertyName("email")]
        public string Email { get; }
    }
}