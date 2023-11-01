using System.Collections.Generic;
using System.Net;

namespace Kettle
{
    public interface IResponse
    {
        /// <summary>
        /// Raw response body. Should be a string.
        /// </summary>
        object Body { get; }

        /// <summary>
        /// Headers for the response.
        /// </summary>
        IReadOnlyDictionary<string, string> Headers { get; }

        /// <summary>
        /// The response status code.
        /// </summary>
        HttpStatusCode StatusCode { get; }
    }
}