using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace screen_fleet_admin.Models
{
    public class MongoContext<Model>
    {
        private readonly IMongoDatabase _database = null;

        public MongoContext(MongoClientContext databaseContext)
        {
            _database = databaseContext.Database;
        }

        public IMongoCollection<Model> Collection
        {
            get
            {
                return _database.GetCollection<Model>("TVModels");
            }
        }
    }
}
