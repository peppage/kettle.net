using System.Net;
using System.Text;

namespace Kettle.Tests.Http
{
    public static class HttpClientAdaptorTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsureDelay()
            {
                Assert.Throws<ArgumentException>(() => new HttpClientAdapter(0));
            }
        }

        public class BuildRequestMethod
        {
            private readonly Uri _endpoint = new("/testing", UriKind.Relative);

            [Fact]
            public void EnsureArguments()
            {
                var tester = new HttpClientAdapterTester();
#pragma warning disable CS8625 // Tests sending a null so ignore this.
                Assert.Throws<ArgumentNullException>(() => tester.BuildRequestTester(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            }

            [Fact]
            public void NoContent()
            {
                var request = new Request(SteamClient.SteamApiUrl, _endpoint, HttpMethod.Get);
                var tester = new HttpClientAdapterTester();

                var requestMessage = tester.BuildRequestTester(request);
                Assert.Null(requestMessage.Content);
            }
        }

        public class BuildResponseMethod
        {
            [Theory]
            [InlineData(HttpStatusCode.OK)]
            [InlineData(HttpStatusCode.NotFound)]
            public async Task BuildResponseFromResponseMessage(HttpStatusCode httpStatusCode)
            {
                var responseMessage = new HttpResponseMessage
                {
                    StatusCode = httpStatusCode,
                    Content = new ByteArrayContent(Encoding.UTF8.GetBytes("{}")),
                    Headers =
                    {
                        { "name", "kettle"
                        },
                    }
                };

                var tester = new HttpClientAdapterTester();

                var response = await tester.BuildResponseTester(responseMessage);

                var header = response.Headers.First();
                Assert.Equal("name", header.Key);
                Assert.Equal("kettle", header.Value);
                Assert.Equal("{}", response.Body);
                Assert.Equal(httpStatusCode, response.StatusCode);
            }
        }

        private sealed class HttpClientAdapterTester : HttpClientAdapter
        {
            public HttpRequestMessage BuildRequestTester(IRequest request)
            {
                return BuildRequest(request);
            }

            public async Task<IResponse> BuildResponseTester(HttpResponseMessage httpResponseMessage)
            {
                return await BuildResponseAsync(httpResponseMessage);
            }
        }
    }
}