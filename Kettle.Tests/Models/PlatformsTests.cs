namespace Kettle.Tests.Models
{
    public class PlatformsTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""windows"": true,
  ""mac"": true,
  ""linux"": true
}";

            var serializer = new SystemTextJsonSerializer();
            var platforms = serializer.Deserialize<Platforms>(json);

            Assert.True(platforms.Mac);
            Assert.True(platforms.Windows);
            Assert.True(platforms.Linux);
        }
    }
}