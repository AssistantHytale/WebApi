using System.Text;
using AssistantHytale.Api.Filter;
using AssistantHytale.Domain.Dto.Enum;
using Microsoft.AspNetCore.Mvc;

namespace AssistantHytale.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AboutController : ControllerBase
    {
        /// <summary>
        /// Get some basic info on the Assistant for Hytale Apps
        /// </summary>
        /// <returns>Basic info about the Assistant for Hytale Apps</returns>
        [HttpGet]
        [CacheFilter(CacheType.About)]
        public IActionResult About()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Privacy Policy: https://hytaleassistant.com/privacy_policy.html");
            sb.AppendLine("Terms & Conditions: https://hytaleassistant.com/terms_and_conditions.html");

            return Ok(sb.ToString());
        }
    }
}
