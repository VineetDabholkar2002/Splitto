using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models
{
    public class User
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [BsonElement("username"), BsonRepresentation(BsonType.String)]
        public string UserName { get; set; } = string.Empty;
        [BsonElement("password"), BsonRepresentation(BsonType.String)]
        [BsonIgnore]
        public string Password { get; set; } = string.Empty;
        [BsonElement("email"), BsonRepresentation(BsonType.String)]
        public string Email { get; set; } = string.Empty;
        [BsonIgnore]
        [BsonElement("mobile_no"), BsonRepresentation(BsonType.String)]
        public string? MobileNo { get; set; } = string.Empty;
    }
}
