using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace screen_fleet_admin.Models
{
    /*! \brief Model used to represent a resource as well as in a database and in the
     * code. A Resource is composed of a type (horizontal-split | vertical-split | data), leaf
     * to bind it to another model, path that contains a specific data
     */
    public class ResourceModel
    {
        [BsonElement("Id")]
        public ObjectId Id { get; set; }

        [BsonElement("RawId")]
        public string RawId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("ResourceType")]
        public string ResourceType { get; set; }

        [BsonElement("Leaf1")]
        public ResourceModel Leaf1 { get; set; }

        [BsonElement("Leaf2")]
        public ResourceModel Leaf2 { get; set; }

        [BsonElement("Path")]
        public string Path { get; set; }

        [BsonElement("InsertionDate")]
        public DateTime InsertionDate { get; set; } = DateTime.Now;

        [BsonElement("UpdateTime")]
        public DateTime UpdateTime { get; set; } = DateTime.Now;

    }
}
