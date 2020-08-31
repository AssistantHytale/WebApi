using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Contract;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Repository.Interface
{
    public interface IGuideDetailRepository: IBasePaginatedRepository<GuideDetail>
    {
        Task<ResultWithValueAndPagination<List<GuideDetailsWithUserInfo>>> GetActiveGuideDetails(int page);
        Task<ResultWithValueAndPagination<List<GuideDetailsWithUserInfo>>> GetActiveGuideDetails(int page, string langCode);
    }
}