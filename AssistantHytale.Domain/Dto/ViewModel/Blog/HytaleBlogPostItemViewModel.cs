using System;

namespace AssistantHytale.Domain.Dto.ViewModel.Blog
{
    public class HytaleBlogPostItemViewModel
    {
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool Featured { get; set; }
        public DateTime PublishedAt { get; set; }
        //public HytaleBlogPostCoverImage CoverImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string CoverImageUrl { get; set; }
        public string BodyExcerpt { get; set; }
        public string Link { get; set; }
    }
}
