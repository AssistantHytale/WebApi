using AssistantHytale.Domain.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AssistantHytale.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        /// <summary>
        /// Google Sign in
        /// </summary>
        [HttpGet]
        [Route("Google")]
        public IActionResult GoogleSignIn()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = ApiUrl.GoogleResponse }, "Google");
        }
    }
}
