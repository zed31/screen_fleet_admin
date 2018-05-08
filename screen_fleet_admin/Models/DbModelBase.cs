using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace screen_fleet_admin.Models
{
    /*! \brief Model base for each model */
    public class DbModelBase
    {
        ObjectId Id { get; set; }

        [BsonElement("RawId")]
        public string RawId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public DateTime InsertionDate { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}
