using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.ViewModel.Guide;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Contract;
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
        /// <param name="page">
        /// The desired page.
        /// </param>
        /// <param name="langCode">
        /// The desired Language code.
        /// </param>
        /// <returns>List of currently active Guides</returns>
        /// <response code="200">Success</response>
        /// <response code="201">No Active Guides that match criteria</response>
        [HttpGet]
        public async Task<ActionResult<List<GuideDetailViewModel>>> GetAllActiveGuideDetails(string langCode, int page = 1)
        {
            ResultWithValueAndPagination<List<GuideDetailsWithUserInfo>> allGuideDetails = await _guideRepo.GetActiveGuideDetails(page, langCode);
            if (allGuideDetails.HasFailed || allGuideDetails.Value.Count == 0) return NoContent();

            List<GuideDetailViewModel> viewModels = allGuideDetails.Value.ToDto(db => db.ToDto());
            return Ok(allGuideDetails.PaginationFromOld(viewModels));
        }

        /// <summary>
        /// Get Guide Details for the specified Guid.
        /// </summary>
        /// <param name="guid">
        /// GuideMeta Guid, available from /GuideMeta.
        /// </param>
        /// <returns>Details of requested Guide</returns>
        /// <response code="200">GuideDetailViewModel containing Guide Details</response>
        /// <response code="400">Could not find Guide requested</response>
        [HttpGet("{guid}")]
        public async Task<ActionResult<GuideDetailViewModel>> GetGuideDetails(Guid guid)
        {
            ResultWithValue<GuideDetail> guideDetailsResult = await _guideRepo.Get(guid);
            if (guideDetailsResult.HasFailed) return BadRequest();

            return Ok(guideDetailsResult.Value.ToDto());
        }
    }
}