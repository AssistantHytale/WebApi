using System.Collections.Generic;
using System.Linq;
using AssistantHytale.Domain.Dto.ViewModel.Blog;
using AssistantHytale.Integration.Entity;

namespace AssistantHytale.Integration.Mapper
{
    public static class HytaleBlogPostMapper
    {
        public static HytaleBlogPostItemViewModel ToDto(this HytaleBlogPostEntity entity)
        {
            HytaleBlogPostItemViewModel vm = new HytaleBlogPostItemViewModel
            {
                Author = entity.Author,
                BodyExcerpt = entity.BodyExcerpt,
                CreatedAt = entity.CreatedAt,
                Featured = entity.Featured,
                PublishedAt = entity.PublishedAt,
                Slug = entity.Slug,
                Title = entity.Title,
                Link = $"https://www.hytale.com/news/{entity.CreatedAt.Year}/{entity.CreatedAt.Month}/{entity.Slug}",
                ThumbnailImageUrl = GetImageUrl(entity.CoverImage, "thumb"),
                CoverImageUrl = GetImageUrl(entity.CoverImage, "cover")
            };
            return vm;
        }
        public static List<HytaleBlogPostItemViewModel> ToDto(this List<HytaleBlogPostEntity> entity) =>
            entity.Select(d => d.ToDto()).ToList();

        public static string GetImageUrl(this HytaleBlogPostCoverImage entity, string containsText)
        {
            if (entity == null) return string.Empty;
            if (entity.Variants.Length == 0)
            {
                if (containsText.Contains("thumb")) return $"https://cdn.hytale.com/variants/blog_thumb_{entity.S3Key}";
                if (containsText.Contains("cover")) return $"https://cdn.hytale.com/variants/blog_cover_{entity.S3Key}";
            }
            foreach (string entityVariant in entity.Variants)
            {
                if (entityVariant.Contains(containsText))
                {
                    return $"https://cdn.hytale.com/variants/{entityVariant}_{entity.S3Key}";
                }
            }
            return string.Empty;
        }

        public static HytaleBlogPostDetailViewModel ToDto(this HytaleBlogPostDetailEntity entity)
        {
            HytaleBlogPostDetailViewModel vm = new HytaleBlogPostDetailViewModel
            {
                Author = entity.Author,
                Body = entity.Body,
                CreatedAt = entity.CreatedAt,
                Featured = entity.Featured,
                PublishedAt = entity.PublishedAt,
                Slug = entity.Slug,
                Title = entity.Title,
                ThumbnailImageUrl = GetImageUrl(entity.CoverImage, "thumb"),
                CoverImageUrl = GetImageUrl(entity.CoverImage, "cover"),
                NextPostSlug = entity?.Next?.Slug ?? string.Empty,
                PreviousPostSlug = entity?.Previous?.Slug ?? string.Empty
            };
            return vm;
        }
    }
}
