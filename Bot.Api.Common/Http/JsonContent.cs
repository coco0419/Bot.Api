namespace Bot.Api.Common.Http
{
    using Newtonsoft.Json;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class JsonContent : HttpContent
    {
        private readonly MemoryStream _memoryStream;

        public JsonContent(object value)
        {
            _memoryStream = new MemoryStream();

            var jsonWriter = new JsonTextWriter(new StreamWriter(_memoryStream));
            jsonWriter.Formatting = Formatting.Indented;

            var serializer = new JsonSerializer();
            serializer.Serialize(jsonWriter, value);

            jsonWriter.Flush();
            _memoryStream.Position = 0;

            Headers.ContentType = new MediaTypeHeaderValue("application/json")
            {
                CharSet = "utf-8"
            };
        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            return _memoryStream.CopyToAsync(stream);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = _memoryStream.Length;

            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _memoryStream.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
