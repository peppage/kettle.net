namespace Kettle
{
    /// <summary>
    /// Wrapper for a response from the API
    /// </summary>
    /// <typeparam name="T">Paylost contained in the response</typeparam>
    public interface IApiResponse<out T>
    {
        /// <summary>
        /// Payload of the response
        /// </summary>
        T Body { get; }

        /// <summary>
        /// The context of the response
        /// </summary>
        IResponse Response { get; }
    }
}