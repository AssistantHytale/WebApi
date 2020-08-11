using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Api.Filter;
using AssistantHytale.Domain.Dto.Enum;
using AssistantHytale.Domain.Dto.ViewModel;
using AssistantHytale.Domain.Dto.ViewModel.Blog;
using AssistantHytale.Domain.Result;
using AssistantHytale.Integration.Entity;
using AssistantHytale.Integration.Mapper;
using AssistantHytale.Integration.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AssistantHytale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HypixelController : ControllerBase
    {
        private readonly IHytaleBlogRepository _hytaleRepo;

        public HypixelController(IHytaleBlogRepository hytaleRepo)
        {
            _hytaleRepo = hytaleRepo;
        }

        /// <summary>
        /// Get Published blogs from https://www.hytale.com/news
        /// </summary>
        [HttpGet("Blog")]
        [CacheFilter(CacheType.PublishedBlogPosts)]
        public async Task<ActionResult<List<HytaleBlogPostItemViewModel>>> GetBlogPosts()
        {
            ResultWithValue<List<HytaleBlogPostEntity>> blogPostResult = await _hytaleRepo.GetPublishedBlogPosts(0);
            if (blogPostResult.HasFailed) return BadRequest("Could not fetch Blog Posts");

            return Ok(blogPostResult.Value.ToDto());
        }

        /// <summary>
        /// Get Published blog content from slug
        /// </summary>
        /// <param name="slug"></param>
        [HttpGet("Blog/{slug}")]
        [CacheFilter(CacheType.PublishedBlogPosts, includeUrl: true)]
        public async Task<ActionResult<HytaleBlogPostDetailViewModel>> GetBlogPostDetails(string slug)
        {
            ResultWithValue<HytaleBlogPostDetailEntity> blogPostResult = await _hytaleRepo.GetPublishedBlogPost(slug);
            if (blogPostResult.HasFailed) return BadRequest("Could not fetch Blog Post");

            return Ok(blogPostResult.Value.ToDto());
        }
    }
}
