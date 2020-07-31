using System.Threading.Tasks;
using AssistantHytale.Domain.Contract;
using AssistantHytale.Domain.Result;

namespace AssistantHytale.Data.Service
{
    public interface IUserService
    {
        Task<ResultWithValue<string>> GetJwtTokenFromOAuthLogin(OAuthUser viewModel);
    }
}