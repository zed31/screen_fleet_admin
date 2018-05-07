using MongoDB.Bson.Serialization.Attributes;

namespace screen_fleet_admin.Models
{
    public class ResourceModel : DbModelBase
    {
        [BsonElement("resourceType")]
        public string ResourceType { get; set; }

        [BsonElement("child1")]
        public ResourceModel Leaf1 { get; set; }

        [BsonElement("child2")]
        public ResourceModel Leaf2 { get; set; }

        [BsonElement("path")]
        public string Path { get; set; }
    }
}
