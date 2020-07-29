using System;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Data.Repository.Interface
{
    public interface IJwtRepository
    {
        ResultWithValue<string> GenerateToken(User user);
        ResultWithValue<string> GenerateToken(string username, Guid userGuid);
    }
}