namespace Bot.Api.Common.Models.Response
{
    using Newtonsoft.Json;

    public class MattermostActionUpdate
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
