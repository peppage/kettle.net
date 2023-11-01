using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kettle.Internal
{
    public interface IHttpClient : IDisposable
    {
        /// <summary>
        /// Sends the request and returns a response.
        /// </summary>
        /// <param name="request">An HTTP request</param>
        /// <param name="cancellationToken">Used to cancel the request</param>
        /// <returns>The response from the server not parsed</returns>
        Task<IResponse> SendAsync(IRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Specify the timeout for the connection between the client and the server.
        /// </summary>
        /// <param name="timeout"></param>
        void SetRequestTimeout(TimeSpan timeout);
    }
}