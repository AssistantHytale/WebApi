using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AssistantHytale.Api.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AssistantHytale.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private SignInManager<ExternalUser> _signInManager;

        /// <summary>
        /// Account
        /// </summary>
        [HttpGet]
        [Route("Google")]
        public async Task<IActionResult> Home(string errorCode, string code)
        {
            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
                return RedirectToAction(nameof(Login));

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            string[] userInfo = { info.Principal.FindFirst(ClaimTypes.Name).Value, info.Principal.FindFirst(ClaimTypes.Email).Value };
            if (result.Succeeded)
                return Ok(new {
                errorCode,
                code,
                additional = userInfo
            });
            return new ForbidResult();
        }

        /// <summary>
        /// Login
        /// </summary>
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return Ok();
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
