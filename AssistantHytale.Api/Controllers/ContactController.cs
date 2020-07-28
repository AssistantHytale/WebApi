using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AssistantHytale.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        /// <summary>
        /// Contact form submission
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ContactFormSubmission([FromBody]ContactFormViewModel form)
        {
            await Task.FromResult(0);
            // TODO - Send Slack message to #Hytale
            return Ok();
        }
    }
}
