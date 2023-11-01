namespace Kettle.Tests.Models
{
    public class MovieLinksTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""480"": ""http://cdn.akamai.steamstatic.com/steam/apps/256698790/movie480.webm?t=1659929753"",
  ""max"": ""http://cdn.akamai.steamstatic.com/steam/apps/256698790/movie_max.webm?t=1659929753""
}";

            var serializer = new SystemTextJsonSerializer();
            var links = serializer.Deserialize<MovieLinks>(json);

            Assert.Equal("http://cdn.akamai.steamstatic.com/steam/apps/256698790/movie480.webm?t=1659929753", links.Resolution480);
            Assert.Equal("http://cdn.akamai.steamstatic.com/steam/apps/256698790/movie_max.webm?t=1659929753", links.ResolutionMax);
        }
    }
}