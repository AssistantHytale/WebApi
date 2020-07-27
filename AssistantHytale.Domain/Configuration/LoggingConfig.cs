using AssistantHytale.Domain.Configuration.Interface;

namespace AssistantHytale.Domain.Configuration
{
    public class Logging: ILogging
    {
        public string Default { get; set; }
        public string System { get; set; }
        public string Microsoft { get; set; }
    }
}
