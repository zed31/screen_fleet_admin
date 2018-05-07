using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace screen_fleet_admin.Models
{
    /*! \brief Model used to represent a TV in the database and in the repositories / 
     * controllers. A TV is represented by an Ip address and a Resource
     */
    public class TVModel : DbModelBase
    {
        [BsonElement("Ip address")]
        public string Ip { get; set; }

        [BsonElement("Resource")]
        public ResourceModel Resource { get; set; }
    }
}
