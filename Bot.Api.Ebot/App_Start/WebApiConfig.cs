namespace Bot.Api.Ebot
{
    using Bot.Api.Ebot.Configuration;
    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API の設定およびサービス
            EbotConfiguration.Configure();

            // Web API ルート
            config.MapHttpAttributeRoutes();
        }
    }
}
