
namespace AssistantHytale.Domain.Constants
{
    public static class UserConstants
    {
        public static string DefaultProfileServiceUrl = "https://ui-avatars.com/api/?size=128&name=";
        public static string DefaultProfileUrl(string username) => $"{DefaultProfileServiceUrl}{username}";
    }
}
