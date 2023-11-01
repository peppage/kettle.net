namespace Kettle.Tests.Clients
{
    public static class AppsClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsureNullArgumnets()
            {
                Assert.Throws<ArgumentNullException>(() => new AppsClient(null));
            }
        }
    }

    public class TheGetAppListMethod
    {
        [Fact]
        public async Task RequestCorrectUrl()
        {
            var appList = Substitute.For<AppList>(new List<App>());

            var appListContainer = Substitute.For<AppListContainer>(appList);

            var apiResp = Substitute.For<IApiResponse<AppListContainer>>();
            apiResp.Body.Returns(appListContainer);

            var connection = Substitute.For<IConnection>();
            connection.GetApiAsync<AppListContainer>(Arg.Any<Uri>(), null).Returns(apiResp);

            var client = new AppsClient(connection);

            await client.GetAppListAsync();

            await connection.Received().GetApiAsync<AppListContainer>(Arg.Is<Uri>(u => u.ToString() == "ISteamApps/GetAppList/v2/"), null);
        }
    }
}