using System;
using AssistantHytale.Domain.Dto.ViewModel;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Mapper.Dto
{
    public static class UserMapper
    {
        public static User ToPersistence(UserViewModel viewModel)
        {
            User persistence = new User
            {
                Guid = Guid.NewGuid(),
                AssistantAppsUserGuid = viewModel.AssistantAppsUserGuid,
                Username = viewModel.Username,
            };
            return persistence;
        }
    }
}
