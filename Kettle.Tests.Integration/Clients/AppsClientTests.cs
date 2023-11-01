namespace Kettle.Tests.Integration.Clients
{
    public static class AppsClientTests
    {
        public class Methods
        {
            [Fact]
            public async Task GetAppList()
            {
                var steam = Helper.GetAuthClient();

                var appList = await steam.AppsClient.GetAppListAsync();
                Assert.NotNull(appList);
                Assert.Equal("Counter-Strike: Source", appList.First(x => x.AppId == 240).Name);
            }
        }
    }
}