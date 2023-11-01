namespace Kettle.Tests.Models
{
    public class SupportInfoTests
    {
        [Fact]
        public void CanBeDeserialized()
        {
            const string json = @"{
  ""url"": ""http://steamcommunity.com/app/440"",
  ""email"": ""test@test.com""
}";

            var serializer = new SystemTextJsonSerializer();
            var supportInfo = serializer.Deserialize<SupportInfo>(json);

            Assert.Equal("http://steamcommunity.com/app/440", supportInfo.Url);
            Assert.Equal("test@test.com", supportInfo.Email);
        }
    }
}