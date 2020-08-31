using System;
using System.Threading.Tasks;
using AssistantHytale.Data.Helper;
using AssistantHytale.Data.Repository.Interface;
using AssistantHytale.Domain.Contract;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;
using AssistantHytale.Persistence.Mapper;
using AssistantHytale.Persistence.Mapper.Dto;
using AssistantHytale.Persistence.Repository.Interface;

namespace AssistantHytale.Data.Service
{
    public class UserService : IUserService
    {
        private readonly IJwtRepository _jwtRepo;
        private readonly IUserRepository _userRepo;

        public UserService(IJwtRepository jwtRepo, IUserRepository userRepo)
        {
            _jwtRepo = jwtRepo;
            _userRepo = userRepo;
        }

        public async Task<ResultWithValue<string>> GetJwtTokenFromOAuthLogin(OAuthUser domain)
        {
            string emailHash = HashSaltHelper.GetHashString(domain.Email, domain.OAuthUserId);

            ResultWithValue<User> getUserResult = await _userRepo.GetUser(domain.OAuthType, emailHash);
            if (getUserResult.IsSuccess) return _jwtRepo.GenerateToken(getUserResult.Value.Username, getUserResult.Value.Guid);

            User newUser = domain.ToPersistence(new Guid(), emailHash);
            Result createUserResult = await _userRepo.Add(newUser);
            if (createUserResult.IsSuccess) return _jwtRepo.GenerateToken(newUser.Username, newUser.Guid);

            return new ResultWithValue<string>(false, string.Empty, "Could not generate JWT for user");
        }
    }
}
