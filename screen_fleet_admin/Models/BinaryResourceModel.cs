using MongoDB.Bson.Serialization.Attributes;

namespace screen_fleet_admin.Models
{
    public class BinaryResourceModel : ResourceModel
    {
        [BsonElement("Image data")]
        public byte[] Image { get; set; }
    }
}
