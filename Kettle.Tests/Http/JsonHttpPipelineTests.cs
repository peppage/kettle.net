using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Kettle.Internal.TestSetup;

namespace Kettle.Tests.Http
{
    public static class JsonHttpPipelineTests
    {
        public class TheCTor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new JsonHttpPipeline(null));
            }
        }

        public class DeserializeResponseMethod
        {
            [Fact]
            public void DeserializeResponse()
            {
                const string data = "works";
                var httpResponse = CreateResponse(HttpStatusCode.OK, JsonSerializer.Serialize(data));

                var jsonPipeline = new JsonHttpPipeline();

                var response = jsonPipeline.DeserializeResponse<string>(httpResponse);

                Assert.NotNull(response.Body);
                Assert.Equal(data, response.Body);
            }

            [Fact]
            public void DeserializesSingleIntoCollection()
            {
                const string data = "{\"name\":\"Kettle\"}";
                var jsonPipeline = new JsonHttpPipeline();
                var httpResponse = CreateResponse(HttpStatusCode.OK, data);

                var response = jsonPipeline.DeserializeResponse<List<SomeObject>>(httpResponse);

                Assert.Single(response.Body);
                Assert.Equal("Kettle", response.Body.First().Name);
            }

            [Fact]
            public void DeserializeHtml()
            {
                const string data = "<html>";
                var jsonPipeline = new JsonHttpPipeline();
                var httpResponse = CreateResponse(HttpStatusCode.OK, data);

                Assert.Throws<HtmlResponseException>(() => jsonPipeline.DeserializeResponse<SomeObject>(httpResponse));
            }

            public class SomeObject
            {
                [JsonConstructor]
                public SomeObject(string name) => Name = name;

                [JsonPropertyName("name")]
                public string Name { get; set; }
            }
        }
    }
}