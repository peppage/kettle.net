using System.Text.Json;

namespace Kettle.Internal
{
    /// <inheritdoc/>
    public class SystemTextJsonSerializer : IJsonSerializer
    {
        /// <inheritdoc/>
        public T Deserialize<T>(string json) => JsonSerializer.Deserialize<T>(json);
    }
}