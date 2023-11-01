using static Kettle.Internal.TestSetup;

namespace Kettle.Tests.Http
{
    public static class ResponseTests
    {
        public class TheCTor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new Response(System.Net.HttpStatusCode.OK, "test", null));
            }

            [Fact]
            public void InitializeAllrequiredProperties()
            {
                var response = CreateResponse(System.Net.HttpStatusCode.OK);

                Assert.NotNull(response.Headers);
            }
        }
    }
}