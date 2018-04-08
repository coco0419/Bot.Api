namespace Bot.Api.Common.Models.Request
{
    using Newtonsoft.Json;

    public class MattermostActionRequest<T>
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("context")]
        public T Context { get; set; }
    }
}
