using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.Enum;
using Microsoft.EntityFrameworkCore;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Repository.Interface;
using User = AssistantHytale.Persistence.Entity.User;

namespace AssistantHytale.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HytaleAssistantContext _db;

        public UserRepository(HytaleAssistantContext db)
        {
            _db = db;
        }

        public async Task<ResultWithValue<List<User>>> GetAll()
        {
            try
            {
                List<User> users = await _db.Users.ToListAsync();
                return new ResultWithValue<List<User>>(true, users, string.Empty);
            }
            catch (Exception ex)
            {
                return new ResultWithValue<List<User>>(false, new List<User>(), ex.Message);
            }
        }

        public async Task<ResultWithValue<User>> Get(Guid guid)
        {
            try
            {
                User user = await _db.Users.FirstAsync(u => u.Guid.Equals(guid));
                return new ResultWithValue<User>(true, user, string.Empty);
            }
            catch (Exception ex)
            {
                return new ResultWithValue<User>(false, new User(), ex.Message);
            }
        }

        public async Task<ResultWithValue<User>> GetUser(string username)
        {
            try
            {
                User user = await _db.Users.FirstAsync(u => u.Username.Equals(username));
                return new ResultWithValue<User>(true, user, string.Empty);
            }
            catch (Exception ex)
            {
                return new ResultWithValue<User>(false, new User(), ex.Message);
            }
        }

        public async Task<ResultWithValue<User>> GetUserByAssistantAppsGuid(Guid assistantAppsGuid)
        {
            try
            {
                User user = await _db.Users.FirstAsync(u => u.AssistantAppsUserGuid.Equals(assistantAppsGuid));
                return new ResultWithValue<User>(true, user, string.Empty);
            }
            catch (Exception ex)
            {
                return new ResultWithValue<User>(false, new User(), ex.Message);
            }
        }

        public async Task<Result> Add(User addItem)
        {
            bool assistantAppsUserExistsResult = await _db.Users.AnyAsync(u => u.AssistantAppsUserGuid.Equals(addItem.AssistantAppsUserGuid));
            if (assistantAppsUserExistsResult) return new Result(false, "AssistantApps User exists in database");

            try
            {
                await _db.Users.AddAsync(addItem);
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<Result> Edit(User editItem)
        {
            User userToEdit = await _db.Users.FirstAsync(u => u.Guid.Equals(editItem.Guid));
            if (userToEdit == null) return new Result(false, "User does not exist in database");

            userToEdit.Username = editItem.Username;

            try
            {
                _db.Users.Update(userToEdit);
                await _db.SaveChangesAsync();
                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<Result> Delete(Guid userGuid)
        {
            try
            {
                User userToDelete = await _db.Users.FirstAsync(u => u.Guid.Equals(userGuid));
                if (userToDelete == null) return new Result(false, "User does not exist in database");

                _db.Users.Remove(userToDelete);
                await _db.SaveChangesAsync();

                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

    }
}