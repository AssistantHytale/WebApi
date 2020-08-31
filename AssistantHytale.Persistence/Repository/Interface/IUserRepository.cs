using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.Enum;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;

namespace AssistantHytale.Persistence.Repository.Interface
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<ResultWithValue<User>> GetUser(string username);
        Task<ResultWithValue<User>> GetUser(OAuthProviderType oAuthType, string emailHash);
    }
}