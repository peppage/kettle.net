namespace Kettle.Tests.Helpers
{
    public static class UriExtensionsTests
    {
        public class TheApplyParametersMethod
        {
            [Fact]
            public void AppendsParametersAsQueryString()
            {
                var uri = new Uri("https://example.com");

                var uriWithParameters = uri.ApplyParameters(new Dictionary<string, string>
                {
                    {"foo", "foo val"},
                    {"bar", "barval"}
                });

                Assert.Equal(new Uri("https://example.com?foo=foo%20val&bar=barval"), uriWithParameters);
            }

            [Fact]
            public void AppendsParametersAsQueryStringWithRelativeUri()
            {
                var uri = new Uri("issues", UriKind.Relative);

                var uriWithParameters = uri.ApplyParameters(new Dictionary<string, string>
                {
                    {"foo", "fooval"},
                    {"bar", "barval"}
                });

                Assert.Equal(new Uri("issues?foo=fooval&bar=barval", UriKind.Relative), uriWithParameters);
            }

            [Fact]
            public void DoesNotChangeUrlWhenParametersEmpty()
            {
                var uri = new Uri("https://example.com");

                var uriWithEmptyParameters = uri.ApplyParameters(new Dictionary<string, string>());
                var uriWithNullParameters = uri.ApplyParameters(null);

                Assert.Equal(uri, uriWithEmptyParameters);
                Assert.Equal(uri, uriWithNullParameters);
            }

            [Fact]
            public void DoesNotChangeUrlWhenParametersEmptyWithRelativeUri()
            {
                var uri = new Uri("api/example", UriKind.Relative);

                var uriWithEmptyParameters = uri.ApplyParameters(new Dictionary<string, string>());
                var uriWithNullParameters = uri.ApplyParameters(null);

                Assert.Equal(uri, uriWithEmptyParameters);
                Assert.Equal(uri, uriWithNullParameters);
            }

            [Fact]
            public void CombinesExistingParametersWithNewParameters()
            {
                var uri = new Uri("https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002?appid=1090760");

                var parameters = new Dictionary<string, string> { { "appid", "3" }, { "maxlength", "1" }, { "count", "3" } };

                var actual = uri.ApplyParameters(parameters);

                Assert.Equal(
                    new Uri("https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002?appid=3&maxlength=1&count=3"),
                    actual);
            }

            [Fact]
            public void CombinesExistingParametersWithNewParametersToRelativeUri()
            {
                var uri = new Uri("ISteamNews/GetNewsForApp/v0002?appid=1090760", UriKind.Relative);

                var parameters = new Dictionary<string, string> { { "appid", "3" }, { "maxlength", "1" }, { "count", "3" } };

                var actual = uri.ApplyParameters(parameters);

                Assert.Equal(
                    new Uri("ISteamNews/GetNewsForApp/v0002?appid=3&maxlength=1&count=3", UriKind.Relative),
                    actual);
            }

            [Fact]
            public void DoesNotChangePassedInDictionary()
            {
                var uri = new Uri("https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002?appid=1090760");

                var parameters = new Dictionary<string, string> { { "maxlength", "1" }, { "count", "3" } };

                uri.ApplyParameters(parameters);

                Assert.Equal(2, parameters.Count);
            }

            [Fact]
            public void DoesNotChangePassedInDictionaryForRelativeUri()
            {
                var uri = new Uri("ISteamNews/GetNewsForApp/v0002?appid=1090760", UriKind.Relative);

                var parameters = new Dictionary<string, string> { { "maxlength", "1" }, { "count", "3" } };

                uri.ApplyParameters(parameters);

                Assert.Equal(2, parameters.Count);
            }

            [Fact]
            public void EnsuresArgumentNotNull()
            {
#pragma warning disable CS8600 // Testing for null
                Uri uri = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Assert.Throws<ArgumentNullException>(() => uri!.ApplyParameters(new Dictionary<string, string>()));
            }
        }
    }
}