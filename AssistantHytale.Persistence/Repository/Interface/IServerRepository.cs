using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Repository.Interface
{
    public interface IServerRepository
    {
        Task<ResultWithValueAndPagination<List<Server>>> GetAll(int page);
        Task<Result> Add(Server addServer);
        Task<Result> Edit(Server editServer);
        Task<Result> Delete(Guid guid);
    }
}