namespace Bot.Api.Ebot.Configuration
{
    using System.Configuration;

    public class EbotTeamIdElement : ConfigurationElement
    {
        [ConfigurationProperty("value", DefaultValue = null, IsRequired = true)]
        public string Value
        {
            get { return this["value"] != null && !string.IsNullOrEmpty(this["value"].ToString()) ? this["value"].ToString() : null; }
            set { this["value"] = value; }
        }
    }
}