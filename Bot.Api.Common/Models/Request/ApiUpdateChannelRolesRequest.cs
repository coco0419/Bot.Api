namespace Bot.Api.Common.Models.Request
{
    using Newtonsoft.Json;

    public class ApiUpdateChannelRolesRequest
    {
        [JsonProperty("roles")]
        public string Roles { get; set; }
    }
}
