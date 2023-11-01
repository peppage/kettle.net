namespace Kettle.Tests.Integration.Clients
{
    public static class NewsClientTests
    {
        public class Methods
        {
            [Fact]
            public async Task GetNews()
            {
                var steam = Helper.GetAuthClient();

                var appNews = await steam.NewsClient.GetNewsAsync(440, count: 1);

                Assert.Equal((uint)440, appNews.AppId);
                Assert.NotEqual(0, appNews.Count);
                Assert.NotEmpty(appNews.NewsItems);

                var news = appNews.NewsItems[0];

                Assert.NotEqual("", news.Title);
                Assert.NotEqual("", news.Contents);
            }
        }
    }
}