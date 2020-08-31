using System.Collections.Generic;
using System.Threading.Tasks;
using AssistantHytale.Domain.Result;
using AssistantHytale.Integration.Entity;

namespace AssistantHytale.Integration.Repository.Interface
{
    public interface IHytaleBlogRepository
    {
        Task<ResultWithValueAndPagination<List<HytaleBlogPostEntity>>> GetPublishedBlogPosts(int page);
        Task<ResultWithValue<HytaleBlogPostDetailEntity>> GetPublishedBlogPost(string slug);
    }
}