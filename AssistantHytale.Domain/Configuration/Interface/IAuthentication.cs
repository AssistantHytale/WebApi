namespace AssistantHytale.Domain.Configuration.Interface
{
    public interface IAuthentication
    {
        GoogleAuth GoogleAuth { get; set; }
    }

    public interface IGoogleAuth
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }
    }
}
