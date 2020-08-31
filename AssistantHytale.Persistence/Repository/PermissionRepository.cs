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

        public async Task<ResultWithValue<List<PermissionType>>> GetPermissionsForUserId(Guid userGuid)
        {
            try
            {
                User user = await _db.Users.FirstOrDefaultAsync(u => u.Guid.Equals(userGuid));
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

        public async Task<Result> AddPermissionsForUserId(Guid userGuid, PermissionType permission)
        {
            try
            {
                User user = await _db.Users.FirstOrDefaultAsync(u => u.Guid.Equals(userGuid));
                if (user == null) return new Result(false, "User not found");

                user.Permissions.Add(new UserPermission
                {
                    UserGuid = userGuid,
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

        public async Task<Result> DeletePermissionsForUserId(Guid userGuid, PermissionType permission)
        {
            try
            {
                UserPermission toDelete = await _db.UserPermissions
                    .Where(up => up.UserGuid.Equals(userGuid))
                    .Where(up => up.PermissionType.Equals(permission))
                    .FirstOrDefaultAsync();
                if (toDelete == null) return new Result(false, "Permission not assigned to User, cannot delete");

                _db.UserPermissions.Remove(toDelete);
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
