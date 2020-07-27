using AssistantHytale.Domain.Configuration.Interface;

namespace AssistantHytale.Domain.Configuration
{
    public class Authentication: IAuthentication
    {
        public GoogleAuth GoogleAuth { get; set; }
    }

    public class GoogleAuth: IGoogleAuth
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
