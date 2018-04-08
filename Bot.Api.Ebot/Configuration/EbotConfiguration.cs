namespace Bot.Api.Ebot.Configuration
{
    using System.Configuration;

    public static class EbotConfiguration
    {
        public static EbotConfigSection Ebot { get; set; }

        public static void Configure()
        {
            Ebot = ConfigurationManager.GetSection("ebot") as EbotConfigSection;
        }
    }
}