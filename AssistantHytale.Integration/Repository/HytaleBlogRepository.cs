using System.Collections.Generic;
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

        public async Task<ResultWithValue<List<HytaleBlogPostEntity>>> GetPublishedBlogPosts(int page)
        {
            ResultWithValue<List<HytaleBlogPostEntity>> blogPostsResult = await Get<List<HytaleBlogPostEntity>>($"{_baseUrl}{_publishedBlogsUrl}");

            if (blogPostsResult.HasFailed) return new ResultWithValue<List<HytaleBlogPostEntity>>(false, new List<HytaleBlogPostEntity>(), blogPostsResult.ExceptionMessage);

            return blogPostsResult;
        }

        public async Task<ResultWithValue<HytaleBlogPostDetailEntity>> GetPublishedBlogPost(string slug)
        {
            ResultWithValue<HytaleBlogPostDetailEntity> blogPostResult = await Get<HytaleBlogPostDetailEntity>($"{_baseUrl}{_specificPublishedBlogUrl}{slug}");

            if (blogPostResult.HasFailed) return new ResultWithValue<HytaleBlogPostDetailEntity>(false, new HytaleBlogPostDetailEntity(), blogPostResult.ExceptionMessage);

            return blogPostResult;
        }
    }
}
