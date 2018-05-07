using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace screen_fleet_admin.Contexts
{
    /*! \brief Database context of MongoDB 
     * the template parameter is a model of the database, for instance `TVModel`
     */
    public class MongoContext<Model>
    {
        private readonly IMongoDatabase _database = null;

        /*! \brief Constructor of the MongoContext class
         * @param[in]   databaseContext the client used to connect to the MongoDB database
         */
        public MongoContext(MongoClientContext databaseContext)
        {
            _database = databaseContext.Database;
        }

        /*! \brief Get the specific collection and return it
         * @param[in]   collectionName  the name of the collection to be retrieved
         * @return      an IMongoCollection templated to the specific model
         */
        public IMongoCollection<Model> Collection(string collectionName)
        {
            return _database.GetCollection<Model>(collectionName);
        }
    }
}
