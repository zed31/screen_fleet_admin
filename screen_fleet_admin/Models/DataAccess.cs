using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace screen_fleet_admin.Models
{
    public class DataAccess
    {
        MongoClient _client;
        IMongoDatabase _database;

        DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _database = _client.GetDatabase("ScreenFleet");
        }
    }
}
