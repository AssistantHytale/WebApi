using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Repository.Interface
{
    public interface IGuideMetaRepository
    {
        Task<ResultWithValue<List<GuideMeta>>> GetGuideMetas();
        Task<ResultWithValue<List<GuideMeta>>> GetGuideMetasForUser(Guid userGuid);
        Task<ResultWithValue<GuideMeta>> GetGuideMeta(Guid guid);
        Task<Result> LikeGuide(Guid guid);
        Task<Result> UpdateGuideMeta(GuideMeta guideMeta);
        Task<Result> CreateGuideMeta(GuideMeta guideMeta);
        Task<Result> DeleteGuideMeta(Guid guid);
    }
}