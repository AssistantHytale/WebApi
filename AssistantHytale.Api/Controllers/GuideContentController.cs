using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.ViewModel.Guide;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Contract;
using AssistantHytale.Persistence.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AssistantHytale.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GuideContentController : ControllerBase
    {
        private readonly IGuideContentRepository _guideContentRepo;

        public GuideContentController(IGuideContentRepository guideContentRepo)
        {
            _guideContentRepo = guideContentRepo;
        }

        /// <summary>
        /// Get All Sections and Section Items from Guide with specified Guide guid.
        /// </summary>
        /// <param name="guid">
        /// The desired guide's unique id.
        /// </param>
        /// <returns>List of currently active Guides</returns>
        /// <response code="200">Success</response>
        /// <response code="201">No Guides that match the specified guid</response>
        [HttpGet]
        public async Task<ActionResult<List<GuideDetailViewModel>>> GetGuideContent(Guid guid)
        {
            ResultWithValue<GuideFullContent> guideContent = await _guideContentRepo.GetFullContentById(guid);
            if (guideContent.HasFailed) return NoContent();

            return Ok();
        }
    }
}
