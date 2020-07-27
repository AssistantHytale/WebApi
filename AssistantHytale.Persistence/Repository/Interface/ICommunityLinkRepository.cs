using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Repository.Interface
{
    public interface ICommunityLinkRepository
    {
        Task<ResultWithValue<List<CommunityLink>>> GetAllCommunityLinks();
        Task<Result> AddCommunityLink(CommunityLink addCommunityLink);
        Task<Result> EditCommunityLink(CommunityLink editCommunityLink);
        Task<Result> DeleteCommunityLink(Guid guid);
    }
}