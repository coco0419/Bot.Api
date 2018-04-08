namespace Bot.Api.Common.Models.Response
{
    using Newtonsoft.Json;

    public class MattermostActionResponse
    {
        [JsonProperty("ephemeral_text")]
        public string EphemeralText { get; set; }
        
        [JsonProperty("update")]
        public MattermostActionUpdate Update { get; set; }
    }
}
