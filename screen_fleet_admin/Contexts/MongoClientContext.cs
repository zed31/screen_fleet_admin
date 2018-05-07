using Microsoft.Extensions.Options;
using MongoDB.Driver;
using screen_fleet_admin.Models;

namespace screen_fleet_admin.Contexts
{
    /*! \brief Class used to define a specific connection context with MongoDB */
    public class MongoClientContext
    {
        private readonly IMongoDatabase _database = null;

        /*! \brief Constructor of the MongoClientContext
         * @param[in]   settings    the global settings of the application
         */
        public MongoClientContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        /*! \brief Return the specific database context of the MongoDB connection 
         * @return a IMongoDatabase interface containing the specific connection if the connection works, false
         * otherwise
         */
        public IMongoDatabase Database
        {
            get
            {
                return _database;
            }
        }
    }
}
