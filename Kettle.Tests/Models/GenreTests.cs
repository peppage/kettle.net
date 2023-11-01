namespace Kettle.Tests.Models
{
    public class GenreTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""id"": ""1"",
  ""description"": ""Action""
}";

            var serializer = new SystemTextJsonSerializer();
            var genre = serializer.Deserialize<Genre>(json);

            Assert.Equal("1", genre.Id);
            Assert.Equal("Action", genre.Description);
        }
    }
}