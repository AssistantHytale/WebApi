using AssistantHytale.Domain.Dto.Enum;

namespace AssistantHytale.Domain.Contract
{
    public class OAuthUser
    {
        public OAuthProviderType OAuthType { get; set; }
        public string OAuthUserId { get; set; }
        public string ProfileUrl { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
