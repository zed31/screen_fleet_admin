using MongoDB.Bson.Serialization.Attributes;

namespace screen_fleet_admin.Models
{
    /*! \brief Model used to represent a resource as well as in a database and in the
     * code. A Resource is composed of a type (horizontal-split | vertical-split | data), leaf
     * to bind it to another model, path that contains a specific data
     */
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
