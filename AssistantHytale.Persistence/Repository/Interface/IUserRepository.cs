using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Repository.Interface
{
    public interface IUserRepository
    {
        Task<Result> CreateUser(User user);
        Task<Result> EditUser(User user);
        Task<Result> DeleteUser(Guid userGuid);
        Task<ResultWithValue<User>> GetUser(Guid guid);
        Task<ResultWithValue<User>> GetUser(string username);
        Task<ResultWithValue<User>> GetUser(string username, string passwordHash);
        Task<ResultWithValue<List<User>>> GetUsers();
    }
}