namespace Kettle.Tests
{
    public static class SteamClientTests
    {
        public class TheApiKeyProperty
        {
            [Fact]
            public void ApiKeyIsSaved()
            {
                var key = "asedf";
                var client = new SteamClient(key);
                Assert.Same(key, client.ApiKey);
            }
        }

        public class TheBaseAddressProperty
        {
            [Fact]
            public void IsSetToSteam()
            {
                var client = new SteamClient("sdaf");
                Assert.Equal(new Uri("https://api.steampowered.com/"), client.BaseApiAddress);
                Assert.Equal(new Uri("https://store.steampowered.com/"), client.BaseStoreAddress);
            }
        }

        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new SteamClient((IConnection)null));
                Assert.Throws<ArgumentNullException>(() => new SteamClient((IHttpClient)null));
                Assert.Throws<ArgumentNullException>(() => new SteamClient("sdfas", (IHttpClient)null));
            }
        }
    }
}