using System;
using AssistantHytale.Domain.Constants;
using AssistantHytale.Domain.Contract;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Mapper.Dto
{
    public static class UserMapper
    {
        public static User ToPersistence(this OAuthUser oAuth, Guid guid, string emailHash)
        {
            User persistence = new User
            {
                Guid = guid,
                OAuthType = oAuth.OAuthType,
                Username = oAuth.Username,
                OAuthUserId = oAuth.OAuthUserId,
                EmailHash = emailHash,
                Email = oAuth.Email,
                JoinDate = DateTime.Now,
                ProfileImageUrl = string.IsNullOrEmpty(oAuth.ProfileUrl)
                    ? UserConstants.DefaultProfileUrl(oAuth.Username)
                    : oAuth.ProfileUrl,
            };
            return persistence;
        }
    }
}
