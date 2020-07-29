using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.ViewModel;
using AssistantHytale.Domain.Result;

namespace AssistantHytale.Data.Service
{
    public interface IUserService
    {
        Task<ResultWithValue<string>> GetJwtTokenFromOAuthLogin(OAuthUserViewModel viewModel);
    }
}