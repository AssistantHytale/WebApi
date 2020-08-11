using System;
using System.Threading.Tasks;
using AssistantHytale.Data.Service;
using AssistantHytale.Domain.Contract;
using AssistantHytale.Domain.Dto.Enum;
using AssistantHytale.Domain.Dto.ViewModel;
using AssistantHytale.Domain.Result;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;

namespace AssistantHytale.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// OAuth Login
        /// </summary>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] OAuthUserViewModel oauthVm)
        {
            if (oauthVm.OAuthType == OAuthProviderType.Unknown) return BadRequest("Invalid OAuth login");

            OAuthUser domain = null;
            if (oauthVm.OAuthType == OAuthProviderType.Google)
            {
                try
                {
                    GoogleJsonWebSignature.Payload payload =
                        await GoogleJsonWebSignature.ValidateAsync(oauthVm.TokenId);
                    domain = new OAuthUser
                    {
                        Email = payload.Email,
                        Username = payload.Name,
                        OAuthUserId = payload.Subject,
                        ProfileUrl = payload.Picture,
                        OAuthType = OAuthProviderType.Google
                    };
                }
                catch (Exception)
                {
                    return BadRequest("Google OAuth Login failed");
                }
            }

            if(domain == null) return BadRequest("OAuth Login failed");

            ResultWithValue<string> jwtResult = await _userService.GetJwtTokenFromOAuthLogin(domain);
            if (jwtResult.HasFailed) return BadRequest("Login failed");

            return Ok(jwtResult.Value);
        }

        /// <summary>
        /// Logout
        /// </summary>
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}
