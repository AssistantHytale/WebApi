using Microsoft.AspNetCore.Mvc;

namespace AssistantHytale.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Google Sign in
        /// </summary>
        [HttpGet]
        [Route("Google")]
        public IActionResult GoogleSignIn()
        {
            return RedirectPermanent("https://scrapassistant.com/favicon.ico");
        }
    }
}
