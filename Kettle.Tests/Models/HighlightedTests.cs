namespace Kettle.Tests.Models
{
    public class HighlightedTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""name"": ""Head of the Class"",
  ""path"": ""https://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/440/tf_play_game_everyclass.jpg""
}";

            var serializer = new SystemTextJsonSerializer();
            var highlight = serializer.Deserialize<Highlighted>(json);

            Assert.Equal("Head of the Class", highlight.Name);
            Assert.Equal("https://cdn.akamai.steamstatic.com/steamcommunity/public/images/apps/440/tf_play_game_everyclass.jpg", highlight.Path);
        }
    }
}