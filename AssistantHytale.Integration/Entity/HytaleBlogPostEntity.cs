using System;
using Newtonsoft.Json;

namespace AssistantHytale.Integration.Entity
{
    public class HytaleBlogPostEntity
    {
        [JsonProperty("featured")]
        public bool Featured { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("publishedAt")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("coverImage")]
        public HytaleBlogPostCoverImage CoverImage { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("bodyExcerpt")]
        public string BodyExcerpt { get; set; }

        //public object[] tags { get; set; }
    }

    public class HytaleBlogPostCoverImage
    {
        [JsonProperty("variants")]
        public string[] Variants { get; set; }

        [JsonProperty("s3Key")]
        public string S3Key { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        //public string _id { get; set; }
        //public string mimeType { get; set; }
        //public bool attached { get; set; }
        //public int __v { get; set; }
        //public string contentId { get; set; }
        //public string contentType { get; set; }
    }

}