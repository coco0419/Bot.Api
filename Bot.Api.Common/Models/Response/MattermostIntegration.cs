namespace Bot.Api.Common.Models.Response
{
    using Newtonsoft.Json;

    public class MattermostIntegration
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("context")]
        public object Context { get; set; }
    }
}
