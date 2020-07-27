using AssistantHytale.Domain.Configuration.Interface;

namespace AssistantHytale.Domain.Configuration
{
    public class ApiConfiguration: IApiConfiguration
    {
        public string[] AllowedHosts { get; set; }
        public ApplicationInsights ApplicationInsights { get; set; }
        public Database Database { get; set; }
        public Authentication Authentication { get; set; }
        public Logging Logging { get; set; }
    }
}
