namespace System.Net.Http
{
    using Bot.Api.Common.Http;

    public static class HttpRequestMessageExtensions
    {
        public static HttpResponseMessage CreateJsonResponse(this HttpRequestMessage source, object value)
        {
            return new HttpResponseMessage()
            {
                Content = new JsonContent(value)
            };
        }
    }
}
