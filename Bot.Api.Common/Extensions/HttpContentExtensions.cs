namespace System.Net.Http
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Net.Http.Formatting;

    public static class HttpContentExtensions
    {
        public static Task<T> ReadAsJsonAsync<T>(this HttpContent source) => source.ReadAsAsync<T>(GetJsonMediaTypeFormatter());

        private static IEnumerable<MediaTypeFormatter> GetJsonMediaTypeFormatter()
        {
            yield return new JsonMediaTypeFormatter();
        }
    }
}
