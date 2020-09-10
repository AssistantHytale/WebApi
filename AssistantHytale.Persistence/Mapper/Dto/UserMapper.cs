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
                Username = oAuth.Username,
                // TODO redo mapping
            };
            return persistence;
        }
    }
}
