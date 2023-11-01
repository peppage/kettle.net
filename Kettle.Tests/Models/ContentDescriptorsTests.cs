namespace Kettle.Tests.Models
{
    public class ContentDescriptorsTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
    ""ids"": [
      2,
      5
    ],
    ""notes"": ""Includes cartoon violence and gore.""
  }";

            var serializer = new SystemTextJsonSerializer();
            var content = serializer.Deserialize<ContentDescriptors>(json);

            Assert.Equal(2, content.Ids[0]);
            Assert.Equal("Includes cartoon violence and gore.", content.Notes);
        }
    }
}