namespace Bot.Api.Ebot.Models.Service
{
    using Bot.Api.Common.Models.Response;
    using System.Threading.Tasks;

    public interface IEbotService
    {
        Task<MattermostResponse> VoteCreateChannel(string userId, string userName, string channelName);
        Task<MattermostActionResponse> ExecuteCreateChannel(string userId, string channelName);
    }
}
