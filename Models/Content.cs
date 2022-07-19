using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogSiteAPI.Models
{
    public class Content
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string MediaId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
        public string FeaturedMediaID { get; set; }
        public string UpdateDate { get; set; }
        public string CreateDate { get; set; }
        public string PublishDate { get; set; }
        public string IsActive { get; set; }
        public string IsDeleted { get; set; }
        public string Author { get; set; }
        public string CategoryId { get; set; }
        public string TagId { get; set; }
        public string Slug { get; set; }
    }
}
