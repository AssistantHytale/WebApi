namespace AssistantHytale.Domain.Configuration.Interface
{
    public interface IApiConfiguration
    {
        string[] AllowedHosts { get; set; }
        ApplicationInsights ApplicationInsights { get; set; }
        Authentication Authentication { get; set; }
        Database Database { get; set; }
        Logging Logging { get; set; }
    }
}
