namespace Bot.Api.Ebot.Models.Service
{
    using Bot.Api.Common.Models.Request;
    using Bot.Api.Common.Models.Response;
    using Bot.Api.Common.Models.Service;
    using Bot.Api.Ebot.Configuration;
    using HashidsNet;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class EbotService : IEbotService
    {
        private readonly IMattermostClientService _mattermostClientService;

        public EbotService() : this(new MattermostClientService(EbotConfiguration.Ebot.ApiHost.Value, EbotConfiguration.Ebot.AuthorizationToken.Value)) { }

        public EbotService(IMattermostClientService mattermostClientService)
        {
            _mattermostClientService = mattermostClientService;
        }

        public Task<MattermostResponse> VoteCreateChannel(string userId, string userName, string channelName)
        {
            return Task.Run(() => new MattermostResponse()
            {
                UserName = "ebot",
                Text = string.Format("@{0}", userName),
                Attachments = new[]
                {
                    new MattermostAttachment()
                    {
                        Text = @"下記名称でチャンネルを作成します。よろしいですか？",
                        Fields = new[]
                        {
                            new MattermostField()
                            {
                                Short = false,
                                Title = "チャンネル名",
                                Value = channelName
                            }
                        },
                        Actions = new[]
                        {
                            new MattermostAction()
                            {
                                Name = "はい",
                                Integration = new MattermostIntegration()
                                {
                                    Url = string.Format("{0}/api/incoming/channel/vote", EbotConfiguration.Ebot.Host.Value),
                                    Context = new MattermostCreateChannelRequest()
                                    {
                                        Vote = true,
                                        ChannelName = channelName,
                                        UserId = userId
                                    }
                                }
                            },
                            new MattermostAction()
                            {
                                Name = "いいえ",
                                Integration = new MattermostIntegration()
                                {
                                    Url = string.Format("{0}/api/incoming/channel/vote", EbotConfiguration.Ebot.Host.Value),
                                    Context = new MattermostCreateChannelRequest()
                                    {
                                        Vote = false,
                                        ChannelName = channelName,
                                        UserId = userId
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }

        public async Task<MattermostActionResponse> ExecuteCreateChannel(string userId, string channelName)
        {
            var serviceResponse = await _mattermostClientService.CreateChannel(new ApiCreateChannelRequest()
            {
                TeamId = EbotConfiguration.Ebot.TeamId.Value,
                Name = CreateHash(channelName),
                DisplayName = channelName,
                Type = "P"
            })
            .ConfigureAwait(false);

            if (serviceResponse.StatusCode == HttpStatusCode.Created)
            {
                var apiResponse = serviceResponse.Content.ReadAsJsonAsync<ApiCreateChannelResponse>();

                await _mattermostClientService.AddChannelUser(apiResponse.Result.Id, new ApiAddChannelUserRequest()
                {
                    UserId = userId
                })
                .ConfigureAwait(false);

                await _mattermostClientService.UpdateChannelRoles(apiResponse.Result.Id, userId, new ApiUpdateChannelRolesRequest()
                {
                    Roles = "channel_user channel_admin"
                })
                .ConfigureAwait(false);

                return new MattermostActionResponse()
                {
                    Update = new MattermostActionUpdate()
                    {
                        Message = string.Format("チャンネル「{0}」を作成しました。", channelName)
                    }
                };
            }

            return new MattermostActionResponse()
            {
                EphemeralText = "チャンネル作成時にエラーが発生しました。管理者に連絡してください。"
            };
        }
        
        private string CreateHash(string salt)
        {
            var random = new Random();

            return new Hashids(salt, 16, "abcdefghijklmnopqrstuvwxyz1234567890", "cfhistu").Encode(Enumerable.Range(0, 3).Select(_ => random.Next()).ToArray());
        }
    }
}