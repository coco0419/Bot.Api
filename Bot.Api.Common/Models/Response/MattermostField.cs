namespace Bot.Api.Common.Models.Response
{
    using Newtonsoft.Json;

    public class MattermostField
    {
        [JsonProperty("short")]
        public bool Short { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
