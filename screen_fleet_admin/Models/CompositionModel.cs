using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace screen_fleet_admin.Models
{
    public class CompositionModel
    {
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public DateTime InsertionDate { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; } = DateTime.Now;

    }
}
