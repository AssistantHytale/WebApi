using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.Enum;
using AssistantHytale.Domain.Dto.ViewModel.Guide;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;
using AssistantHytale.Persistence.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AssistantHytale.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GuideDetailController : ControllerBase
    {
        private readonly IGuideDetailRepository _guideRepo;

        public GuideDetailController(IGuideDetailRepository guideRepo)
        {
            _guideRepo = guideRepo;
        }

        /// <summary>
        /// Get All Guides that are active Details.
        /// </summary>
        /// <param name="lang">
        /// The desired Language.
        /// </param>
        [HttpGet]
        public async Task<ActionResult<List<GuideDetailViewModel>>> GetAllActiveGuideDetails(LanguageType lang = LanguageType.English)
        {
            ResultWithValue<List<GuideDetail>> allGuideDetails = await _guideRepo.GetActiveGuideDetails(lang);
            if (allGuideDetails.HasFailed || allGuideDetails.Value.Count == 0) return NoContent();

            //return Ok(allGuideDetails.Value.ToViewModel());
            return Ok();
        }

        /// <summary>
        /// Get Guide Details for the specified Guid.
        /// </summary>
        /// <param name="guid">
        /// GuideMeta Guid, available from /GuideMeta.
        /// </param>
        /// <param name="lang">
        /// The desired Language.
        /// </param>  
        [HttpGet("{guid}")]
        public async Task<ActionResult<GuideDetailViewModel>> GetGuideDetails(Guid guid, LanguageType lang = LanguageType.English)
        {
            ResultWithValue<GuideDetail> guideDetailsResult = await _guideRepo.GetGuideDetail(guid, lang);
            if (guideDetailsResult.HasFailed) return new GuideDetailViewModel();

            //return Ok(guideDetailsResult.Value.ToViewModel());
            return Ok();
        }
    }
}