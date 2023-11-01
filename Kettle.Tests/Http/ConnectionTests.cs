using System.Net;

using static Kettle.Internal.TestSetup;

namespace Kettle.Tests.Http
{
    public static class ConnectionTests
    {
        private const string exampleUrl = "http://example.com";
        private const string exampleUrl2 = "http://example2.com";
        private static readonly Uri _exampleUri = new(exampleUrl);
        private static readonly Uri _example2Uri = new(exampleUrl2);
        private const string _exampleApiKey = "asdf";

        public class TheGetMethod
        {
            [Fact]
            public async Task SendPropelyFormattedRequest()
            {
                var httpClient = Substitute.For<IHttpClient>();

                var response = CreateResponse(HttpStatusCode.OK);

                httpClient.SendAsync(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(_exampleApiKey, httpClient, _exampleUri, _example2Uri);

                await connection.GetApiAsync<string>(new Uri("endpoint", UriKind.Relative), null);

                await httpClient.Received(1).SendAsync(Arg.Is<IRequest>(req =>
                    req.BaseAddress == _exampleUri &&
                    req.Method == HttpMethod.Get &&
                    req.Endpoint == new Uri("endpoint", UriKind.Relative)), Args.CancellationToken);
            }
        }

        public class TheCtor
        {
            [Fact]
            public void EnsureAbsoluteBaseAddress()
            {
                var httpClient = Substitute.For<IHttpClient>();

                Assert.Throws<ArgumentException>(() =>
                    new Connection(_exampleApiKey, httpClient, new Uri("foo", UriKind.Relative), new Uri("foo", UriKind.Relative)));

                Assert.Throws<ArgumentException>(() =>
                    new Connection(_exampleApiKey, httpClient, new Uri("foo", UriKind.RelativeOrAbsolute), new Uri("foo", UriKind.RelativeOrAbsolute)));

                Assert.Throws<ArgumentException>(() =>
                    new Connection(_exampleApiKey, httpClient, new Uri("http://example.com", UriKind.Absolute), new Uri("foo", UriKind.Relative)));

                Assert.Throws<ArgumentException>(() =>
                    new Connection(_exampleApiKey, httpClient, new Uri("http://example.com", UriKind.Absolute), new Uri("foo", UriKind.RelativeOrAbsolute)));
            }

            [Fact]
            public void EnsuresNonNullArguments()
            {
                var httpClient = Substitute.For<IHttpClient>();

                Assert.Throws<ArgumentNullException>(() => new Connection((IHttpClient)null));
                Assert.Throws<ArgumentNullException>(() => new Connection(_exampleApiKey, (IHttpClient)null));
                Assert.Throws<ArgumentNullException>(() => new Connection(_exampleApiKey, (IHttpClient)null, _exampleUri, _exampleUri));
                Assert.Throws<ArgumentNullException>(() => new Connection(_exampleApiKey, httpClient, (Uri)null, _exampleUri));
                Assert.Throws<ArgumentNullException>(() => new Connection(_exampleApiKey, httpClient, _exampleUri, (Uri)null));
            }

            [Fact]
            public void CreateConnectionWithBaseAddress()
            {
                var httpClient = Substitute.For<IHttpClient>();

                var connection = new Connection(_exampleApiKey, httpClient, _exampleUri, _example2Uri);

                Assert.Equal(_exampleUri, connection.BaseApiAddress);
                Assert.Equal(_example2Uri, connection.BaseStoreAddress);
            }
        }
    }
}