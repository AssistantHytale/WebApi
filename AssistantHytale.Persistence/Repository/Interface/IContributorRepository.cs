using System.Threading.Tasks;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Repository.Interface
{
    public interface IContributorRepository: IBaseRepository<Contributor>
    {
        Task<ResultWithValue<int>> NumberOfContributors();
    }
}