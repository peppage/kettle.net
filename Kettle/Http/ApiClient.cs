namespace Kettle
{
    /// <summary>
    /// A base class for an API client
    /// </summary>
    public abstract class ApiClient
    {
        /// <summary>
        /// Initializes a new API client.
        /// </summary>
        /// <param name="connection">The client's connection</param>
        protected ApiClient(IConnection connection)
        {
            Ensure.ArgumentNotNull(connection, nameof(connection));

            Connection = connection;
        }

        /// <summary>
        /// The api client's connection
        /// </summary>
        protected IConnection Connection { get; }
    }
}