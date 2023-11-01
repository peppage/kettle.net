namespace Kettle.Tests.Models
{
    public class CategoryTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""id"": 1,
  ""description"": ""Multi-player""
}";

            var serializer = new SystemTextJsonSerializer();
            var category = serializer.Deserialize<Category>(json);

            Assert.Equal(1, category.Id);
            Assert.Equal("Multi-player", category.Description);
        }
    }
}