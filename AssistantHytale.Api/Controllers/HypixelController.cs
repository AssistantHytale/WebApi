using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Api.Filter;
using AssistantHytale.Domain.Dto.Enum;
using AssistantHytale.Domain.Dto.ViewModel.Blog;
using AssistantHytale.Domain.Result;
using AssistantHytale.Integration.Entity;
using AssistantHytale.Integration.Mapper;
using AssistantHytale.Integration.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AssistantHytale.Api.Controllers
{
    [Route("[controller]")]
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
        /// <param name="page">
        /// The page of news items
        /// </param>
        /// <returns>List of published blogs from https://www.hytale.com/news</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Could not fetch Blog Posts</response>
        [HttpGet("Blog")]
        [HttpGet("Blog/{page}")]
        [CacheFilter(CacheType.PublishedBlogPosts, includeUrl: true)]
        public async Task<ActionResult<List<HytaleBlogPostItemViewModel>>> GetBlogPosts(int page = 1)
        {
            ResultWithValueAndPagination<List<HytaleBlogPostEntity>> blogPostResult = await _hytaleRepo.GetPublishedBlogPosts(page);
            if (blogPostResult.HasFailed) return BadRequest("Could not fetch Blog Posts");

            return Ok(blogPostResult.PaginationFromOld(blogPostResult.Value.ToDto()));
        }

        /// <summary>
        /// Get Published blog content from slug
        /// </summary>
        /// <param name="slug">
        /// Id of a specific blog post from https://www.hytale.com/news
        /// </param>
        /// <returns>Details of a published blog from https://www.hytale.com/news</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Could not fetch Blog Post</response>
        [HttpGet("BlogDetail/{slug}")]
        [CacheFilter(CacheType.PublishedBlogPosts, includeUrl: true)]
        public async Task<ActionResult<HytaleBlogPostDetailViewModel>> GetBlogPostDetails(string slug)
        {
            ResultWithValue<HytaleBlogPostDetailEntity> blogPostResult = await _hytaleRepo.GetPublishedBlogPost(slug);
            if (blogPostResult.HasFailed) return BadRequest("Could not fetch Blog Post");

            return Ok(blogPostResult.Value.ToDto());
        }
    }
}
