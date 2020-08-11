using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.ViewModel.Guide;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;
using AssistantHytale.Persistence.Mapper;
using AssistantHytale.Persistence.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssistantHytale.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GuideMetaController : ControllerBase
    {
        private readonly IGuideMetaRepository _guideMetaRepo;

        public GuideMetaController(IGuideMetaRepository guideMetaRepo)
        {
            _guideMetaRepo = guideMetaRepo;
        }

        /// <summary>
        /// Get GuideMetas for user.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<GuideMetaViewModel>> GetGuideMetas()
        {
            //TODO Check userId in VM is correct for JWT
            Guid userGuid = new Guid();
            ResultWithValue<List<GuideMeta>> guideMetasResult = await _guideMetaRepo.GetGuideMetasForUser(userGuid);
            if (guideMetasResult.HasFailed) return NoContent();

            return Ok(guideMetasResult.Value.ToDto());
        }

        /// <summary>
        /// Get specific GuideMeta.
        /// </summary>
        /// <param name="guid">
        /// GuideMeta Guid, available from /GuideMeta/Admin.
        /// </param>  
        [HttpGet("{guid}")]
        public async Task<ActionResult<GuideMetaViewModel>> GetGuideMetas(Guid guid)
        {
            ResultWithValue<GuideMeta> guideMeta = await _guideMetaRepo.GetGuideMeta(guid);
            if (guideMeta.HasFailed) return NoContent();

            return Ok(guideMeta.Value.ToDto());
        }


        /// <summary>
        /// Create new GuideMeta
        /// </summary>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateGuideMeta(AddGuideMetaViewModel addUser)
        {
            //TODO Check userId in VM is correct for JWT
            GuideMeta newMeta = addUser.ToPersistence();
            Result guideMeta = await _guideMetaRepo.CreateGuideMeta(newMeta);
            if (guideMeta.HasFailed) return NoContent();

            return Ok(newMeta.Guid);
        }
    }
}