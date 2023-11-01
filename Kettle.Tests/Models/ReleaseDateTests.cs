namespace Kettle.Tests.Models
{
    public class ReleaseDateTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""coming_soon"": true,
  ""date"": ""10 Oct, 2007""
}";

            var serializer = new SystemTextJsonSerializer();
            var releasedate = serializer.Deserialize<ReleaseDate>(json);

            Assert.True(releasedate.ComingSoon);
            Assert.Equal("10 Oct, 2007", releasedate.Date);
        }
    }
}