using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace screen_fleet_admin.Models
{
    public class TreeResourceModel : ResourceModel
    {
        [BsonElement("Resource type name")]
        public string ResourceSplitType { get; set; }

        public ResourceModel Leaf1 { get; set; }
        public ResourceModel Leaf2 { get; set; }
    }
}
