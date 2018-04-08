namespace Bot.Api.Ebot.Controllers
{
    using Bot.Api.Common.Models;
    using Bot.Api.Common.Models.Request;
    using Bot.Api.Common.Models.Response;
    using Bot.Api.Ebot.Models.Service;
    using System.Net;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Web.Http;

    [RoutePrefix("api")]
    public class EbotController : ApiController
    {
        private readonly IEbotService _ebotService;

        public EbotController() : this(new EbotService()) { }

        public EbotController(IEbotService ebotService)
        {
            _ebotService = ebotService;
        }

        [HttpPost, Route("incoming")]
        public async Task<HttpResponseMessage> Incoming([FromBody]MattermostRequest request)
        {
            return await new Bot<Task<HttpResponseMessage>>(request?.Text)
                .Polling(new Regex(@"^@ebot\s+mtg\s+(.+)", RegexOptions.IgnoreCase), async m => Request.CreateJsonResponse(await _ebotService.VoteCreateChannel(request.UserId, request.UserName, m.Groups[1].Value).ConfigureAwait(false)))
                .Execute(() => Task.Run(() => Request.CreateResponse(HttpStatusCode.BadRequest)))
                .ConfigureAwait(false);
        }

        [HttpPost, Route("incoming/channel/vote")]
        public async Task<HttpResponseMessage> IncomingCreateChannel([FromBody]MattermostActionRequest<MattermostCreateChannelRequest> request)
        {
            if (request?.Context.Vote == true)
            {
                return Request.CreateJsonResponse(await _ebotService.ExecuteCreateChannel(request.Context.UserId, request.Context.ChannelName).ConfigureAwait(false));
            }
            else
            {

                return Request.CreateJsonResponse(new MattermostActionResponse()
                {
                    Update = new MattermostActionUpdate()
                    {
                        Message = "チャンネル作成を取り消しました。"
                    }
                });
            }
        }
    }
}