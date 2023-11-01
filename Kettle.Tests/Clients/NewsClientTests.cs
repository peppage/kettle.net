using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kettle.Tests.Clients
{
    public static class NewsClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsureNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => { new NewsClient(null); });
            }
        }

        public class TheGetNewsMethod
        {
            [Fact]
            public async Task RequestCorrectUrl()
            {
                var appNews = Substitute.For<AppNews>((uint)1, new List<News>(), 1);
                var newsContainer = Substitute.For<NewsContainer>(appNews);

                var apiResp = Substitute.For<IApiResponse<NewsContainer>>();
                apiResp.Body.Returns(newsContainer);

                var connection = Substitute.For<IConnection>();
                connection.GetApiAsync<NewsContainer>(Arg.Any<Uri>(), Arg.Any<Dictionary<string, string>>()).Returns(apiResp);

                var client = new NewsClient(connection);

                await client.GetNewsAsync(1);

                await connection.Received().GetApiAsync<NewsContainer>(Arg.Is<Uri>(u => u.ToString() == "ISteamNews/GetNewsForApp/v0002?appid=1"), Arg.Any<Dictionary<string, string>>());
            }

            [Fact]
            public async Task NullResponse()
            {
                var connection = Substitute.For<IConnection>();
                connection.GetApiAsync<NewsContainer>(Arg.Any<Uri>(), Arg.Any<Dictionary<string, string>>()).Returns((IApiResponse<NewsContainer>)null);

                var client = new NewsClient(connection);

                await Assert.ThrowsAsync<SteamAppException>(() => client.GetNewsAsync(1));
            }

            [Fact]
            public async Task NullBody()
            {
                var appNews = Substitute.For<AppNews>((uint)1, new List<News>(), 1);
                var newsContainer = Substitute.For<NewsContainer>(appNews);

                var apiResp = Substitute.For<IApiResponse<NewsContainer>>();
                apiResp.Body.Returns((NewsContainer)null);

                var connection = Substitute.For<IConnection>();
                connection.GetApiAsync<NewsContainer>(Arg.Any<Uri>(), Arg.Any<Dictionary<string, string>>()).Returns(apiResp);

                var client = new NewsClient(connection);

                await Assert.ThrowsAsync<SteamAppException>(() => client.GetNewsAsync(1));
            }
        }
    }
}