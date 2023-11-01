namespace Kettle.Tests.Models
{
    public class AppListTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
    ""apps"": [
      {
        ""appid"": 5,
        ""name"": ""Dedicated Server""
      },
      {
        ""appid"": 7,
        ""name"": ""Steam Client""
      },
      {
        ""appid"": 8,
        ""name"": ""winui2""
      },
      {
        ""appid"": 10,
        ""name"": ""Counter-Strike""
      },
      {
        ""appid"": 20,
        ""name"": ""Team Fortress Classic""
      }
    ]
}";
            var serializer = new SystemTextJsonSerializer();
            var applist = serializer.Deserialize<AppList>(json);

            Assert.Equal((uint)5, applist.Apps[0].AppId);
            Assert.Equal("Counter-Strike", applist.Apps[3].Name);
        }
    }
}