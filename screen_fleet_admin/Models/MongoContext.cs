﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace screen_fleet_admin.Models
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<TVModels> TVModels
        {
            get
            {
                return _database.GetCollection<TVModels>("TVModels");
            }
        }
    }
}