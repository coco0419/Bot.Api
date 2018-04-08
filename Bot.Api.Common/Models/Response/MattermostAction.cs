namespace Bot.Api.Common.Models.Response
{
    using Newtonsoft.Json;

    public class MattermostAction
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("integration")]
        public MattermostIntegration Integration { get; set; }
    }
}
