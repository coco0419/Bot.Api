namespace Bot.Api.Common.Models.Request
{
    using Newtonsoft.Json;

    public class MattermostCreateChannelRequest
    {
        [JsonProperty("vote")]
        public bool Vote { get; set; }

        [JsonProperty("channel_name")]
        public string ChannelName { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
