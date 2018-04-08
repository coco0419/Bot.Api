namespace Bot.Api.Common.Models.Service
{
    using Bot.Api.Common.Models.Request;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class MattermostClientService : IMattermostClientService
    {
        private static HttpClient _httpClient = new HttpClient();

        private readonly string _apiHost;
        
        public MattermostClientService(string apiHost, string authorizationToken)
        {
            _apiHost = apiHost;

            if (_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
            }

            _httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", authorizationToken));
        }

        public Task<HttpResponseMessage> CreateChannel(ApiCreateChannelRequest request)
        {
            return _httpClient.PostAsJsonAsync(CreateUrl("channels"), request);
        }

        public Task<HttpResponseMessage> AddChannelUser(string channelId, ApiAddChannelUserRequest request)
        {
            return _httpClient.PostAsJsonAsync(CreateUrl(string.Format("channels/{0}/members", channelId)), request);
        }

        public Task<HttpResponseMessage> UpdateChannelRoles(string channelId, string userId, ApiUpdateChannelRolesRequest request)
        {
            return _httpClient.PutAsJsonAsync(CreateUrl(string.Format("channels/{0}/members/{1}/roles", channelId, userId)), request);
        }

        private string CreateUrl(string action)
        {
            return string.Format("{0}/api/v4/{1}", _apiHost, action);
        }
    }
}
