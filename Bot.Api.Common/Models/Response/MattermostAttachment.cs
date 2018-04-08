namespace Bot.Api.Common.Models.Response
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class MattermostAttachment
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("fields")]
        public IEnumerable<MattermostField> Fields { get; set; }

        [JsonProperty("actions")]
        public IEnumerable<MattermostAction> Actions { get; set; }
    }
}
