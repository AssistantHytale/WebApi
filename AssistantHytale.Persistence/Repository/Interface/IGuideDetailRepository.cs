using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Repository.Interface
{
    public interface IGuideDetailRepository: IBaseRepository<GuideDetail>
    {
        Task<ResultWithValueAndPagination<List<GuideDetail>>> GetActiveGuideDetails();
        Task<ResultWithValueAndPagination<List<GuideDetail>>> GetActiveGuideDetails(string langCode);
    }
}