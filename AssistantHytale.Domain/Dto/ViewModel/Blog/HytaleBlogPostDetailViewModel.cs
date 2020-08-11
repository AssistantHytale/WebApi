using System;

namespace AssistantHytale.Domain.Dto.ViewModel.Blog
{
    public class HytaleBlogPostDetailViewModel
    {
        public string Slug { get; set; }
        public bool Featured { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PreviousPostSlug { get; set; }
        public string NextPostSlug { get; set; }
    }
}
