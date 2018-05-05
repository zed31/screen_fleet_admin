using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace screen_fleet_admin.Models
{
    public class TVModels
    {
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Ip address")]
        public string Ip { get; set; }

        public DateTime InsertionDate { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}
