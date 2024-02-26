using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NetCoreMVC.Models.Entities
{
    public class User
    {
        [BsonId]
        [BsonElement("UniqueId")]
        public string UniqueId { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }
    }
}
