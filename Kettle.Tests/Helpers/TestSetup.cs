using System.Net;

namespace Kettle.Internal
{
    public static class TestSetup
    {
        public static IResponse CreateResponse(HttpStatusCode statusCode)
        {
            object body = null;
            return CreateResponse(statusCode, body);
        }

        public static IResponse CreateResponse(HttpStatusCode statusCode, object body)
        {
            return new Response(statusCode, body, new Dictionary<string, string>());
        }
    }
}