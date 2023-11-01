namespace Kettle.Tests.Models
{
    public class MetacriticTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""score"": 92,
  ""url"": ""https://www.metacritic.com/game/pc/team-fortress-2?ftag=MCD-06-10aaa1f""
}";

            var serializer = new SystemTextJsonSerializer();
            var metacritic = serializer.Deserialize<Metacritic>(json);

            Assert.Equal(92, metacritic.Score);
            Assert.Equal("https://www.metacritic.com/game/pc/team-fortress-2?ftag=MCD-06-10aaa1f", metacritic.Url);
        }
    }
}