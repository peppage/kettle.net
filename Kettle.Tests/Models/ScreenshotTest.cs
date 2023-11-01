namespace Kettle.Tests.Models
{
    public class ScreenshotTest
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""id"": 1,
  ""path_thumbnail"": ""https://cdn.akamai.steamstatic.com/steam/apps/440/ss_ea21f7bbf4f79bada4554df5108d04b6889d3453.600x338.jpg?t=1665425286"",
  ""path_full"": ""https://cdn.akamai.steamstatic.com/steam/apps/440/ss_ea21f7bbf4f79bada4554df5108d04b6889d3453.1920x1080.jpg?t=1665425286""
}";

            var serializer = new SystemTextJsonSerializer();
            var screenshot = serializer.Deserialize<Screenshot>(json);

            Assert.Equal(1, screenshot.Id);
            Assert.Equal("https://cdn.akamai.steamstatic.com/steam/apps/440/ss_ea21f7bbf4f79bada4554df5108d04b6889d3453.600x338.jpg?t=1665425286", screenshot.PathThumbnail);
            Assert.Equal("https://cdn.akamai.steamstatic.com/steam/apps/440/ss_ea21f7bbf4f79bada4554df5108d04b6889d3453.1920x1080.jpg?t=1665425286", screenshot.PathFull);
        }
    }
}