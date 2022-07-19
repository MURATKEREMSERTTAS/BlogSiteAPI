using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogSiteAPI.Models
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ContentId { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Text { get; set; }
        public string IsAproved { get; set; }
    }
}
