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
        private int _pageSize = 10;
        private readonly string _baseUrl = "https://hytale.com/api";
        private readonly string _publishedBlogsUrl = "/blog/post/published";
        private readonly string _specificPublishedBlogUrl = "/blog/post/slug/";

        public async Task<PaginationResultWithValue<List<HytaleBlogPostEntity>>> GetPublishedBlogPosts(int page)
        {
            ResultWithValue<List<HytaleBlogPostEntity>> blogPostsResult = await Get<List<HytaleBlogPostEntity>>($"{_baseUrl}{_publishedBlogsUrl}");

            if (blogPostsResult.HasFailed) return new PaginationResultWithValue<List<HytaleBlogPostEntity>>(false, new List<HytaleBlogPostEntity>(), 
                0, 0, blogPostsResult.ExceptionMessage
            );
            
            int totalPages = (int)Math.Ceiling((double)blogPostsResult.Value.Count / _pageSize);

            if (page < 1) page = 1;
            if (page > totalPages) page = totalPages;

            List<HytaleBlogPostEntity> list = blogPostsResult.Value.Skip((page - 1) * _pageSize).Take(_pageSize).ToList();
            return new PaginationResultWithValue<List<HytaleBlogPostEntity>>(true, list, page, totalPages, string.Empty);
        }

        public async Task<ResultWithValue<HytaleBlogPostDetailEntity>> GetPublishedBlogPost(string slug)
        {
            ResultWithValue<HytaleBlogPostDetailEntity> blogPostResult = await Get<HytaleBlogPostDetailEntity>($"{_baseUrl}{_specificPublishedBlogUrl}{slug}");

            if (blogPostResult.HasFailed) return new ResultWithValue<HytaleBlogPostDetailEntity>(false, new HytaleBlogPostDetailEntity(), blogPostResult.ExceptionMessage);

            return blogPostResult;
        }
    }
}
