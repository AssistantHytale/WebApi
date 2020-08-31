using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.Enum;
using AssistantHytale.Domain.Result;

namespace AssistantHytale.Persistence.Repository.Interface
{
    public interface IPermissionRepository
    {
        Task<ResultWithValue<List<PermissionType>>> GetPermissionsForUserId(Guid userGuid);
        Task<Result> AddPermissionsForUserId(Guid userGuid, PermissionType permission);
        Task<Result> DeletePermissionsForUserId(Guid userGuid, PermissionType permission);
    }
}