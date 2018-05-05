using MongoDB.Bson.Serialization.Attributes;

namespace screen_fleet_admin.Models
{
    public class ImageResourceModel : ResourceModel
    {
        [BsonElement("Image data")]
        byte[] Image { get; set; }
    }
}
