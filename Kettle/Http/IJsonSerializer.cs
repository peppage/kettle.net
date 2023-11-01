namespace Kettle.Internal
{
    /// <summary>
    /// Provides functionality to deserialize JSON into objects or value types.
    /// </summary>
    public interface IJsonSerializer
    {
        /// <summary>
        /// Parses the text representing a single JSON value into a <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the JSON value into.</typeparam>
        /// <param name="json">JSON text to parse.</param>
        /// <returns>A <typeparamref name="T"/> representation of the JSON value.</returns>
        T Deserialize<T>(string json);
    }
}