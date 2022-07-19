using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogSiteAPI.Models
{
    public class Author
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IsActive { get; set; }
        public string IsDeleted { get; set; }
    }
}
