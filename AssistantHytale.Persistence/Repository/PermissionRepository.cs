using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.Enum;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;
using AssistantHytale.Persistence.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AssistantHytale.Persistence.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly HytaleAssistantContext _db;

        public PermissionRepository(HytaleAssistantContext db)
        {
            _db = db;
        }

        public async Task<ResultWithValue<List<PermissionType>>> GetPermissionsForUserId(Guid guid)
        {
            try
            {
                User user = await _db.Users.FirstOrDefaultAsync(u => u.Guid.Equals(guid));
                if (user == null)
                {
                    return new ResultWithValue<List<PermissionType>>(false, new List<PermissionType>(), "User not found");
                }
                return new ResultWithValue<List<PermissionType>>(true, user.Permissions.Select(p => p.PermissionType).ToList(), string.Empty);
            }
            catch (Exception ex)
            {
                return new ResultWithValue<List<PermissionType>>(false, new List<PermissionType>(), ex.Message);
            }
        }

        public async Task<Result> AddPermissionToUser(Guid guid, PermissionType permission)
        {
            try
            {
                User user = await _db.Users.FirstOrDefaultAsync(u => u.Guid.Equals(guid));
                if (user == null)
                {
                    return new ResultWithValue<List<PermissionType>>(false, new List<PermissionType>(), "User not found");
                }

                user.Permissions.Add(new UserPermission
                {
                    UserGuid = guid,
                    PermissionType = permission,
                });

                await _db.SaveChangesAsync();

                return new Result(true, string.Empty);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<Result> DeletePermissionFromUser(Guid guid, PermissionType permission)
        {
            try
            {
                User user = await _db.Users.FirstOrDefaultAsync(u => u.Guid.Equals(guid));
                if (user == null)
                {
                    return new ResultWithValue<List<PermissionType>>(false, new List<PermissionType>(), "User not found");
                }

                List<UserPermission> userPermissions = user.Permissions.ToList();
                userPermissions.RemoveAll(up => up.PermissionType == permission && up.UserGuid.Equals(guid));
                user.Permissions = userPermissions;

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
