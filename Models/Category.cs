using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogSiteAPI.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string IsActive { get; set; }
        public string IsDeleted { get; set; }
        public string Slug { get; set; }
    }
}
