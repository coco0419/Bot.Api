namespace Bot.Api.Common.Models.Request
{
    using Newtonsoft.Json;

    public class ApiAddChannelUserRequest
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("post_root_id")]
        public string PostRootId { get; set; }
    }
}
