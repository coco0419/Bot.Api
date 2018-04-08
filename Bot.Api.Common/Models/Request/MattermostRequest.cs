namespace Bot.Api.Common.Models.Request
{
    using Newtonsoft.Json;

    public class MattermostRequest
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }
    }
}