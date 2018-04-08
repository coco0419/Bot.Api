namespace Bot.Api.Common.Models.Service
{
    using Bot.Api.Common.Models.Request;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IMattermostClientService
    {
        Task<HttpResponseMessage> CreateChannel(ApiCreateChannelRequest request);
        Task<HttpResponseMessage> AddChannelUser(string channelId, ApiAddChannelUserRequest request);
        Task<HttpResponseMessage> UpdateChannelRoles(string channelId, string userId, ApiUpdateChannelRolesRequest request);
    }
}
