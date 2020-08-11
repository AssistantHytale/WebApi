using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.Enum;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Repository.Interface
{
    public interface IGuideDetailRepository
    {
        Task<ResultWithValue<List<GuideDetail>>> GetGuideDetails();
        Task<ResultWithValue<List<GuideDetail>>> GetActiveGuideDetails(LanguageType lang);
        Task<ResultWithValue<GuideDetail>> GetGuideDetail(Guid guid, LanguageType lang);
        Task<Result> CreateGuideDetail(Guid guideMetaGuid, GuideDetail guideDetail, LanguageType lang);
        Task<Result> UpdateGuideDetail(GuideDetail guideDetail, LanguageType lang);
        Task<Result> DeleteGuideDetail(Guid guid);
    }
}