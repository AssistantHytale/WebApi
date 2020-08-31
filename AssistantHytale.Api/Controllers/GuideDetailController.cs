using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.ViewModel.Guide;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;
using AssistantHytale.Persistence.Mapper.Dto;
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
        /// <param name="langCode">
        /// The desired Language code.
        /// </param>
        [HttpGet]
        public async Task<ActionResult<List<GuideDetailViewModel>>> GetAllActiveGuideDetails(string langCode = "en")
        {
            ResultWithValue<List<GuideDetail>> allGuideDetails = await _guideRepo.GetActiveGuideDetails(langCode);
            if (allGuideDetails.HasFailed || allGuideDetails.Value.Count == 0) return NoContent();

            return Ok(allGuideDetails.Value.ToDto(db => db.ToDto()));
        }

        /// <summary>
        /// Get Guide Details for the specified Guid.
        /// </summary>
        /// <param name="guid">
        /// GuideMeta Guid, available from /GuideMeta.
        /// </param>
        [HttpGet("{guid}")]
        public async Task<ActionResult<GuideDetailViewModel>> GetGuideDetails(Guid guid)
        {
            ResultWithValue<GuideDetail> guideDetailsResult = await _guideRepo.Get(guid);
            if (guideDetailsResult.HasFailed) return new GuideDetailViewModel();

            return Ok(guideDetailsResult.Value.ToDto());
        }
    }
}