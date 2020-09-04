using System;
using System.Threading.Tasks;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Contract;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Repository.Interface
{
    public interface IGuideContentRepository: IBasePaginatedRepository<GuideContent>
    {
        Task<ResultWithValue<GuideFullContent>> GetFullContentById(Guid guid);
    }
}
