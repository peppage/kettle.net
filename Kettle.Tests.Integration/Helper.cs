namespace Kettle.Tests.Integration
{
    public static class Helper
    {
        private static Lazy<string> _steamDevApiKey => new(() =>
        {
            return Environment.GetEnvironmentVariable("KETTLE_APIKEY");
        });

        public static string SteamDevApiKey => _steamDevApiKey.Value;

        public static ISteamClient GetAuthClient()
        {
            return new SteamClient(SteamDevApiKey);
        }
    }
}