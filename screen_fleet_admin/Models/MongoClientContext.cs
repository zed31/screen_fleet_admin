using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace screen_fleet_admin.Models
{
    public class MongoClientContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoClientContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoDatabase Database
        {
            get
            {
                return _database;
            }
        }
    }
}
