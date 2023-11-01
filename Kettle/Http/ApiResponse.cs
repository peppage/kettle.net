namespace Kettle.Internal
{
    internal class ApiResponse<T> : IApiResponse<T>
    {
        public ApiResponse(IResponse response) : this(response, GetBodyAsObject(response))
        { }

        public ApiResponse(IResponse response, T bodyAsObject)
        {
            Ensure.ArgumentNotNull(response, nameof(response));

            Response = response;
            Body = bodyAsObject;
        }

        public T Body { get; private set; }

        public IResponse Response { get; private set; }

        private static T GetBodyAsObject(IResponse response)
        {
            var body = response.Body;
            if (body is T t) return t;
            return default;
        }
    }
}