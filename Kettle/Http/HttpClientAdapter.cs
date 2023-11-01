using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Kettle.Internal
{
    public class HttpClientAdapter : IHttpClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Create instance of HttpClientAdapter with default http client
        /// </summary>
        public HttpClientAdapter()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Create instance of HttpClientAdapter using <see cref="ThrottlingMessageHandler"/> which
        /// addd a delay between calls to not get rate-limited by Valve. If you make too many
        /// requests they will fail but it will not be clear why. A good default is 1500.
        /// </summary>
        /// <param name="delayBetweenCalls">Time between an API call in milliseconds.</param>
        public HttpClientAdapter(int delayBetweenCalls)
        {
            Ensure.ArgumentNotZero(delayBetweenCalls, nameof(delayBetweenCalls));

            var semaphore = new TimeSpanSemaphore(1, TimeSpan.FromMilliseconds(delayBetweenCalls));

            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            }

            var throttlingHandler = new ThrottlingMessageHandler(semaphore, handler);
            _httpClient = new HttpClient(throttlingHandler);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public async Task<IResponse> SendAsync(IRequest request, CancellationToken cancellationToken)
        {
            Ensure.ArgumentNotNull(request, nameof(request));
            var requestMessage = BuildRequest(request);
            var httpClientResponse = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            return await BuildResponseAsync(httpClientResponse).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public void SetRequestTimeout(TimeSpan timeout)
        {
            _httpClient.Timeout = timeout;
        }

        protected virtual HttpRequestMessage BuildRequest(IRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            HttpRequestMessage? requestMessage = null;

            try
            {
                var fullUri = new Uri(request.BaseAddress, request.Endpoint);
                requestMessage = new HttpRequestMessage(request.Method, fullUri);
            }
            catch (Exception)
            {
                requestMessage?.Dispose();
                throw;
            }

            return requestMessage;
        }

        protected virtual async Task<IResponse> BuildResponseAsync(HttpResponseMessage responseMessage)
        {
            Ensure.ArgumentNotNull(responseMessage, nameof(responseMessage));

            var responseBody = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseHeaders = responseMessage.Headers.ToDictionary(h => h.Key, h => h.Value.First());

            return new Response(responseMessage.StatusCode, responseBody, responseHeaders);
        }

        /// <inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _httpClient?.Dispose();
            }
        }
    }
}