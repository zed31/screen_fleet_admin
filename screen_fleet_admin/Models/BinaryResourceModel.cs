using MongoDB.Bson.Serialization.Attributes;

namespace screen_fleet_admin.Models
{
    public class BinaryResourceModel : ResourceModel
    {
        [BsonElement("Binary data")]
        public byte[] BinaryResource { get; set; }
    }
}
