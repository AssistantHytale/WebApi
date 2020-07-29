using AssistantHytale.Domain.Dto.Enum;

namespace AssistantHytale.Domain.Dto.ViewModel
{
    public class OAuthUserViewModel
    {
        public OAuthProviderType OAuthType { get; set; }
        public string AccessToken { get; set; }
        public string OAuthUserId { get; set; }
        public string ProfileUrl { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
