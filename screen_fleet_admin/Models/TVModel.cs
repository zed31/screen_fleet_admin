using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace screen_fleet_admin.Models
{
    public class TVModel : DbModelBase
    {
        [BsonElement("Ip address")]
        public string Ip { get; set; }
    }
}
