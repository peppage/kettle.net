using System;
using System.Net.Http;

namespace Kettle.Internal
{
    /// <summary>
    /// Wrapper for a request to the API
    /// </summary>
    public interface IRequest
    {
        /// <summary>
        /// Base address of the API
        /// </summary>
        Uri BaseAddress { get; }

        /// <summary>
        /// Enpoint added to the <see cref="BaseAddress"/>
        /// </summary>
        Uri Endpoint { get; }

        /// <summary>
        /// HTTP method or verb to use
        /// </summary>
        HttpMethod Method { get; }

        /// <summary>
        /// How long to wait for the request to timeout
        /// </summary>
        TimeSpan Timeout { get; }
    }
}