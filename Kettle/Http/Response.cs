using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;

namespace Kettle
{
    public class Response : IResponse
    {
        public Response(HttpStatusCode statusCode, object body, IDictionary<string, string> headers)
        {
            Ensure.ArgumentNotNull(headers, nameof(headers));

            StatusCode = statusCode;
            Body = body;
            Headers = new ReadOnlyDictionary<string, string>(headers);
        }

        /// <inheritdoc/>
        public object Body { get; private set; }

        /// <inheritdoc/>
        public IReadOnlyDictionary<string, string> Headers { get; private set; }

        /// <inheritdoc/>
        public HttpStatusCode StatusCode { get; private set; }
    }
}