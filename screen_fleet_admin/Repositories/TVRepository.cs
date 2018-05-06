using MongoDB.Bson;
using MongoDB.Driver;
using screen_fleet_admin.Contexts;
using screen_fleet_admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace screen_fleet_admin.Repositories
{
    public class TVRepository : ITVRepository
    {
        private readonly MongoContext<TVModel> _context = null;
        private readonly static string COLLECTION_NAME = "TVModel";

        public TVRepository(MongoContext<TVModel> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TVModel>> GetAllTVScreens()
        {
            return await _context.Collection(COLLECTION_NAME).Find(_ => true).ToListAsync();
        }

        public async Task<TVModel> GetTVScreen(string name)
        {
            ObjectId internalId = RepositoryUtils.GetInternalId(name);
            return await _context.Collection(COLLECTION_NAME).Find(tv => tv.Name == name || tv.Id == internalId).FirstOrDefaultAsync();
        }

        public async Task AddTVScreen(TVModel model)
        {
            await _context.Collection(COLLECTION_NAME).InsertOneAsync(model);
        }

        public async Task<bool> RemoveTVScreen(string name)
        {
            DeleteResult deleteAction = await _context.Collection(COLLECTION_NAME).DeleteOneAsync(Builders<TVModel>.Filter.Eq("Name", name));
            return deleteAction.IsAcknowledged && deleteAction.DeletedCount > 0;
        }

        public async Task<bool> UpdateTVScreen(string name, TVModel tv)
        {
            ReplaceOneResult actionResult = await _context.Collection(COLLECTION_NAME).ReplaceOneAsync(
                s => s.Name == name,
                tv,
                new UpdateOptions { IsUpsert = true }
            );
            return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }

        public async Task<bool> RemoveAllTVScreen()
        {
            DeleteResult actionResult = await _context.Collection(COLLECTION_NAME).DeleteManyAsync(new BsonDocument());
            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }
    }
}
