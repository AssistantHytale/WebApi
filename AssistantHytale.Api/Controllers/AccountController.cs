using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Data.Repository.Interface;
using AssistantHytale.Domain.Configuration.Interface;
using AssistantHytale.Domain.Constants;
using AssistantHytale.Domain.Dto.ViewModel;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;
using AssistantHytale.Persistence.Mapper.Dto;
using AssistantHytale.Persistence.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AssistantHytale.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IJwt _jwtConfig;
        private readonly IUserRepository _userRepo;
        private readonly IJwtRepository _jwtRepo;

        public AccountController(IUserRepository userRepo, IJwtRepository jwtRepo, IJwt jwtConfig)
        {
            _userRepo = userRepo;
            _jwtRepo = jwtRepo;
            _jwtConfig = jwtConfig;
        }

        /// <summary>
        /// Log in for AssistantApp accounts
        /// </summary>
        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserViewModel viewModel)
        {
            User currentUser;
            ResultWithValue<User> existingUserResult = await _userRepo.GetUserByAssistantAppsGuid(viewModel.AssistantAppsUserGuid);
            if (existingUserResult.IsSuccess)
            {
                currentUser = existingUserResult.Value;
            }
            else
            {
                currentUser = UserMapper.ToPersistence(viewModel);
                Result userAddResult = await _userRepo.Add(currentUser);
                if (userAddResult.HasFailed) return BadRequest("Failed to create User");
            }

            ResultWithValue<string> jwtResult = _jwtRepo.GenerateToken(currentUser);
            if (jwtResult.HasFailed) return BadRequest("Could not generate JWT Token");

            Response.Headers.TryAdd(HeaderKey.Token, jwtResult.Value);
            Response.Headers.TryAdd(HeaderKey.UserGuid, existingUserResult.Value.Guid.ToString());
            Response.Headers.TryAdd(HeaderKey.TokenExpiry, _jwtConfig.TimeValidInSeconds.ToString());

            return Ok();
        }
    }
}