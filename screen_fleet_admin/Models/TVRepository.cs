using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace screen_fleet_admin.Models
{
    public class TVRepository : ITVRepository
    {
        private readonly MongoContext<TVModels> _context = null;

        public TVRepository(MongoContext<TVModels> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TVModels>> GetAllTVScreens()
        {
            return await _context.Collection.Find(_ => true).ToListAsync();
        }

        public async Task<TVModels> GetTVScreen(string name)
        {
            ObjectId internalId = this.GetInternalId(name);
            return await _context.Collection.Find(tv => tv.Name == name || tv.Id == internalId).FirstOrDefaultAsync();
        }

        public async Task AddTVScreen(TVModels model)
        {
            await _context.Collection.InsertOneAsync(model);
        }

        public async Task<bool> RemoveTVScreen(string name)
        {
            DeleteResult deleteAction = await _context.Collection.DeleteOneAsync(Builders<TVModels>.Filter.Eq("Name", name));
            return deleteAction.IsAcknowledged && deleteAction.DeletedCount > 0;
        }

        public async Task<bool> UpdateTVScreen(string name)
        {
            var filter = Builders<TVModels>.Filter.Eq(s => s.Name, name);
            var update = Builders<TVModels>.Update.CurrentDate(s => s.UpdateTime);

            UpdateResult actionResult = await _context.Collection.UpdateOneAsync(filter, update);
            return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }

        public async Task<bool> UpdateTVScreen(string name, TVModels tv)
        {
            ReplaceOneResult actionResult = await _context.Collection.ReplaceOneAsync(
                s => s.Name == name,
                tv,
                new UpdateOptions { IsUpsert = true }
            );
            return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }

        public async Task<bool> RemoveAllTVScreen()
        {
            DeleteResult actionResult = await _context.Collection.DeleteManyAsync(new BsonDocument());
            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }

        private ObjectId GetInternalId(string name)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(name, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }
    }
}
