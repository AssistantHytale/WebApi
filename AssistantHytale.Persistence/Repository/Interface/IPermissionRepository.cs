using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.Enum;
using AssistantHytale.Domain.Result;

namespace AssistantHytale.Persistence.Repository.Interface
{
    public interface IPermissionRepository
    {
        Task<ResultWithValue<List<PermissionType>>> GetPermissionsForUserId(Guid guid);
        Task<Result> AddPermissionToUser(Guid guid, PermissionType permission);
        Task<Result> DeletePermissionFromUser(Guid guid, PermissionType permission);
    }
}