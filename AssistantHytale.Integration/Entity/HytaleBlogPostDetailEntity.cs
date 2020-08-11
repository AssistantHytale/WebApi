using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AssistantHytale.Integration.Entity
{
    public class HytaleBlogPostDetailEntity
    {
        [JsonProperty("featured")]
        public bool Featured { get; set; }

        [JsonProperty("tags")]
        public object[] Tags { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("publishedAt")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("coverImage")]
        public HytaleBlogPostCoverImage CoverImage { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("previous")]
        public HytaleBlogPostDetailEntity Previous { get; set; }

        [JsonProperty("next")]
        public HytaleBlogPostDetailEntity Next { get; set; }
        //public string[] publishedTo { get; set; }
        //public bool disableCfAutoplay { get; set; }
        //public int __v { get; set; }
    }
}


