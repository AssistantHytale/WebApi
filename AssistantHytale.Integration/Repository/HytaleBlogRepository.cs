using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistantHytale.Domain.Result;
using AssistantHytale.Integration.Entity;
using AssistantHytale.Integration.Repository.Interface;

namespace AssistantHytale.Integration.Repository
{
    public class HytaleBlogRepository : BaseExternalApiRepository, IHytaleBlogRepository
    {
        private const int PageSize = 10;
        private const string BaseUrl = "https://hytale.com/api";
        private const string PublishedBlogsUrl = "/blog/post/published";
        private const string SpecificPublishedBlogUrl = "/blog/post/slug/";

        public async Task<ResultWithValueAndPagination<List<HytaleBlogPostEntity>>> GetPublishedBlogPosts(int page)
        {
            ResultWithValue<List<HytaleBlogPostEntity>> blogPostsResult = await Get<List<HytaleBlogPostEntity>>($"{BaseUrl}{PublishedBlogsUrl}");

            if (blogPostsResult.HasFailed) return new ResultWithValueAndPagination<List<HytaleBlogPostEntity>>(false, new List<HytaleBlogPostEntity>(), 
                0, 0, 0, blogPostsResult.ExceptionMessage
            );
            
            int totalPages = (int)Math.Ceiling((double)blogPostsResult.Value.Count / PageSize);

            if (page < 1) page = 1;
            if (page > totalPages) page = totalPages;

            List<HytaleBlogPostEntity> list = blogPostsResult.Value.Skip((page - 1) * PageSize).Take(PageSize).ToList();
            return new ResultWithValueAndPagination<List<HytaleBlogPostEntity>>(true, list, 
                page, totalPages, blogPostsResult.Value.Count, 
            string.Empty);
        }

        public async Task<ResultWithValue<HytaleBlogPostDetailEntity>> GetPublishedBlogPost(string slug)
        {
            ResultWithValue<HytaleBlogPostDetailEntity> blogPostResult = await Get<HytaleBlogPostDetailEntity>($"{BaseUrl}{SpecificPublishedBlogUrl}{slug}");

            if (blogPostResult.HasFailed) return new ResultWithValue<HytaleBlogPostDetailEntity>(false, new HytaleBlogPostDetailEntity(), blogPostResult.ExceptionMessage);

            return blogPostResult;
        }
    }
}
