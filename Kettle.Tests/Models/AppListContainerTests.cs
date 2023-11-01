namespace Kettle.Tests.Models
{
    public class AppListContainerTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""applist"": {
    ""apps"": [
      {
        ""appid"": 1941401,
        ""name"": """"
      }
    ]
  }
}";

            var serializer = new SystemTextJsonSerializer();
            var appContainer = serializer.Deserialize<AppListContainer>(json);

            Assert.NotNull(appContainer);
            Assert.NotNull(appContainer.AppList);
        }
    }
}