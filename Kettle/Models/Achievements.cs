using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kettle
{
    public class Achievements
    {
        [JsonConstructor]
        public Achievements(int total, IReadOnlyList<Highlighted> highlighted) =>
            (Total, Highlighted) = (total, highlighted);

        /// <summary>
        /// Total achivements for the app
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; }

        /// <summary>
        /// Rotating selection of achivements shown on the store page
        /// </summary>

        [JsonPropertyName("highlighted")]
        public IReadOnlyList<Highlighted> Highlighted { get; }
    }
}