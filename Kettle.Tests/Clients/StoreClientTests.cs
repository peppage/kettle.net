namespace Kettle.Tests.Clients
{
    public static class StoreClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsureNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new StoreClient(null));
            }
        }

        public class TheAppDetailsMethod
        {
            [Fact]
            public async Task RequestCorrectUrl()
            {
                var appData = Substitute.For<AppData>();
                var appDetails = Substitute.For<AppDetails>(appData, true);

                var apiResp = Substitute.For<IApiResponse<AppDetails>>();
                apiResp.Body.Returns(appDetails);

                var connection = Substitute.For<IConnection>();
                connection.GetStoreAsync<AppDetails>(Arg.Any<Uri>(), null).Returns(apiResp);

                var client = new StoreClient(connection);

                await client.AppDetailsAsync(1);

                await connection.Received().GetStoreAsync<AppDetails>(Arg.Is<Uri>(u => u.ToString() == "api/appdetails/?appids=1"), null);
            }

            [Fact]
            public async Task NullBody()
            {
                var apiResp = Substitute.For<IApiResponse<AppDetails>>();
                apiResp.Body.Returns((AppDetails)null);

                var connection = Substitute.For<IConnection>();
                connection.GetStoreAsync<AppDetails>(Arg.Any<Uri>(), null).Returns(apiResp);

                var client = new StoreClient(connection);

                await Assert.ThrowsAsync<SteamAppException>(() => client.AppDetailsAsync(1));
            }

            [Fact]
            public async Task NoSuccess()
            {
                var appData = Substitute.For<AppData>();
                var appDetails = Substitute.For<AppDetails>(appData, false);

                var apiResp = Substitute.For<IApiResponse<AppDetails>>();
                apiResp.Body.Returns(appDetails);

                var connection = Substitute.For<IConnection>();
                connection.GetStoreAsync<AppDetails>(Arg.Any<Uri>(), null).Returns(apiResp);

                var client = new StoreClient(connection);

                await Assert.ThrowsAsync<NoSuccessException>(() => client.AppDetailsAsync(1));
            }
        }
    }
}