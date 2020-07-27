using AssistantHytale.Domain.Configuration.Interface;

namespace AssistantHytale.Domain.Configuration
{
    public class ApplicationInsights: IApplicationInsights
    {
        public bool Enabled { get; set; }
        public string InstrumentationKey { get; set; }
    }
}
