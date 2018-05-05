using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace screen_fleet_admin.Models
{
    interface IMongoContext
    {
        IMongoCollection<TVModels> TVModels();
        IMongoCollection<CompositionModel> CompositionModels();
    }
}
