namespace Bot.Api.Common.Models.Response
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class MattermostResponse
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("attachments")]
        public IEnumerable<MattermostAttachment> Attachments { get; set; }
    }
}
