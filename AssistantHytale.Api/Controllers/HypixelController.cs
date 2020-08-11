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
        /// <param name="page"></param>
        [HttpGet("Blog")]
        [HttpGet("Blog/{page}")]
        [CacheFilter(CacheType.PublishedBlogPosts, includeUrl: true)]
        public async Task<ActionResult<List<HytaleBlogPostItemViewModel>>> GetBlogPosts(int page = 1)
        {
            PaginationResultWithValue<List<HytaleBlogPostEntity>> blogPostResult = await _hytaleRepo.GetPublishedBlogPosts(page);
            if (blogPostResult.HasFailed) return BadRequest("Could not fetch Blog Posts");

            return Ok(new PaginationResultWithValue<List<HytaleBlogPostItemViewModel>>(true, blogPostResult.Value.ToDto(), 
                blogPostResult.CurrentPage, blogPostResult.TotalPages, string.Empty)
            );
        }

        /// <summary>
        /// Get Published blog content from slug
        /// </summary>
        /// <param name="slug"></param>
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
