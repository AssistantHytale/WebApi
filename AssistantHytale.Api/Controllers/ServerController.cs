using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Dto.ViewModel.Server;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;
using AssistantHytale.Persistence.Repository.Interface;
using AssistantHytale.Persistence.Mapper.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssistantHytale.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private readonly IServerRepository _serverRepo;

        public ServerController(IServerRepository serverRepo)
        {
            _serverRepo = serverRepo;
        }

        /// <summary>
        /// Get All servers with pagination
        /// </summary>
        /// <param name="page">
        /// The page of news items
        /// </param>
        /// <returns>List of Servers submitted by users</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Could not load servers</response>
        [HttpGet]
        public async Task<IActionResult> GetAllServers(int page)
        {
            ResultWithValueAndPagination<List<Server>> serverResult = await _serverRepo.GetAll(page);
            if (serverResult.HasFailed) return BadRequest("Could not load servers");

            List<ServerViewModel> vmList = serverResult.Value.ToDto();
            ResultWithValueAndPagination<List<ServerViewModel>> result =
                new ResultWithValueAndPagination<List<ServerViewModel>>(true, vmList,
                    serverResult.CurrentPage, serverResult.TotalPages, serverResult.TotalRows,
                    string.Empty);
            return Ok(result);
        }

        /// <summary>
        /// Add Server
        /// </summary>
        /// <response code="200">Successfully added submitted Server</response>
        /// <response code="400">Could not add supplied Server</response>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add()
        {
            return Ok();
        }

        /// <summary>
        /// Edit Server
        /// </summary>
        /// <response code="200">Successfully edited submitted Server</response>
        /// <response code="400">Could not edit supplied Server</response>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Edit()
        {
            return Ok();
        }

        /// <summary>
        /// Delete Server
        /// </summary>
        /// <response code="200">Successfully deleted submitted Server</response>
        /// <response code="400">Could not delete supplied Server</response>
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}