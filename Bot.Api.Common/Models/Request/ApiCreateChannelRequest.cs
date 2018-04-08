namespace Bot.Api.Common.Models.Request
{
    using Newtonsoft.Json;

    public class ApiCreateChannelRequest
    {
        [JsonProperty("team_id")]
        public string TeamId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("purpose")]
        public string Purpose { get; set; }

        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
