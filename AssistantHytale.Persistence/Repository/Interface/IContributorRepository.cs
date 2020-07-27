using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Repository.Interface
{
    public interface IContributorRepository
    {
        Task<ResultWithValue<List<Contributor>>> GetAllContributors();
        Task<Result> AddContributor(Contributor addContributor);
        Task<Result> EditContributor(Contributor editContributor);
        Task<Result> DeleteContributor(Guid guid);
        Task<ResultWithValue<int>> NumberOfContributors();
    }
}