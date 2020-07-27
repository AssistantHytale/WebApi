using System;
using Microsoft.AspNetCore.Mvc;

namespace AssistantHytale.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// Account
        /// </summary>
        [HttpGet]
        public IActionResult Home(string errorCode, string code)
        {
            return Ok(new {
                errorCode,
                code
            });
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
