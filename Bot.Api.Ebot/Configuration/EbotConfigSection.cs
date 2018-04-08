namespace Bot.Api.Ebot.Configuration
{
    using System.Configuration;

    public class EbotConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("host", DefaultValue = null, IsRequired = true)]
        public EbotHostElement Host
        {
            get { return this["host"] != null ? (EbotHostElement)this["host"] : new EbotHostElement(); }
            set { this["host"] = value; }
        }

        [ConfigurationProperty("apiHost", DefaultValue = null, IsRequired = true)]
        public EbotApiHostElement ApiHost
        {
            get { return this["apiHost"] != null ? (EbotApiHostElement)this["apiHost"] : new EbotApiHostElement(); }
            set { this["apiHost"] = value; }
        }

        [ConfigurationProperty("authorizationToken", DefaultValue = null, IsRequired = true)]
        public EbotAuthorizationTokenElement AuthorizationToken
        {
            get { return this["authorizationToken"] != null ? (EbotAuthorizationTokenElement)this["authorizationToken"] : new EbotAuthorizationTokenElement(); }
            set { this["authorizationToken"] = value; }
        }

        [ConfigurationProperty("teamId", DefaultValue = null, IsRequired = true)]
        public EbotTeamIdElement TeamId
        {
            get { return this["teamId"] != null ? (EbotTeamIdElement)this["teamId"] : new EbotTeamIdElement(); }
            set { this["teamId"] = value; }
        }
    }
}