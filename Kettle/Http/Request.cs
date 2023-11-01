using System;
using System.Net.Http;

namespace Kettle.Internal
{
    /// <inheritdoc/>
    public class Request : IRequest
    {
        /// <summary>
        /// Create a new instance of Request
        /// </summary>
        public Request(Uri baseAddress, Uri endpoint, HttpMethod method)
        {
            BaseAddress = baseAddress;
            Endpoint = endpoint;
            Method = method;
            Timeout = TimeSpan.FromSeconds(100);
        }

        /// <inheritdoc/>
        public Uri BaseAddress { get; set; }

        /// <inheritdoc/>
        public Uri Endpoint { get; set; }

        /// <inheritdoc/>
        public HttpMethod Method { get; set; }

        /// <inheritdoc/>s
        public TimeSpan Timeout { get; set; }
    }
}