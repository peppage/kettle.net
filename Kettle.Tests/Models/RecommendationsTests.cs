namespace Kettle.Tests.Models
{
    public class RecommendationsTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""total"": 17152
}";

            var serializer = new SystemTextJsonSerializer();
            var recommendation = serializer.Deserialize<Recommendations>(json);

            Assert.Equal(17152, recommendation.Total);
        }
    }
}