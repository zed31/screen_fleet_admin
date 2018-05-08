using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace screen_fleet_admin.Models
{
    /*! \brief Model used to represent a TV in the database and in the repositories / 
     * controllers. A TV is represented by an Ip address and a Resource
     */
    public class TVModel
    {
        [BsonElement("Id")]
        public ObjectId Id { get; set; }

        [BsonElement("RawId")]
        public string RawId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Ip")]
        public string Ip { get; set; }

        [BsonElement("Resource")]
        public ResourceModel Resource { get; set; }

        [BsonElement("InsertionDate")]
        public DateTime InsertionDate { get; set; } = DateTime.Now;

        [BsonElement("UpdateTime")]
        public DateTime UpdateTime { get; set; } = DateTime.Now;

    }
}
