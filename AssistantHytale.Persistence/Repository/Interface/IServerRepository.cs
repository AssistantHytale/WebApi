using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Repository.Interface
{
    public interface IServerRepository: IBaseRepository<Server>
    {
        Task<ResultWithValueAndPagination<List<Server>>> GetAll(int page);
    }
}