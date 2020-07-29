using System.Threading.Tasks;
using AssistantHytale.Data.Service;
using AssistantHytale.Domain.Dto.Enum;
using AssistantHytale.Domain.Dto.ViewModel;
using AssistantHytale.Domain.Result;
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

            ResultWithValue<string> jwtResult = await _userService.GetJwtTokenFromOAuthLogin(oauthVm);
            if (jwtResult.HasFailed) return BadRequest("Login failed");

            return Ok(jwtResult.Value);
        }

        /// <summary>
        /// Login
        /// </summary>
        [HttpGet]
        [Route("/signin-google")]
        public IActionResult SigninGoogle()
        {
            return Ok();
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
