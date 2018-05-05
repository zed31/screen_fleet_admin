using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace screen_fleet_admin.Models
{
    public class TVRepository : IRepository
    {
        private readonly MongoContext _context = null;

        public TVRepository(IOptions<Settings> settings)
        {
            _context = new MongoContext(settings);
        }

        public async Task<IEnumerable<TVModels>> GetAllTVScreens()
        {
            return await _context.TVModels.Find(_ => true).ToListAsync();
        }

        public async Task<TVModels> GetTVScreen(string name)
        {
            ObjectId internalId = this.GetInternalId(name);
            return await _context.TVModels.Find(tv => tv.Name == name || tv.Id == internalId).FirstOrDefaultAsync();
        }

        public async Task AddTVScreen(TVModels model)
        {
            await _context.TVModels.InsertOneAsync(model);
        }

        public async Task<bool> RemoveTVScreen(string name)
        {
            DeleteResult deleteAction = await _context.TVModels.DeleteOneAsync(Builders<TVModels>.Filter.Eq("Name", name));
            return deleteAction.IsAcknowledged && deleteAction.DeletedCount > 0;
        }

        public async Task<bool> UpdateTVScreen(string name)
        {
            var filter = Builders<TVModels>.Filter.Eq(s => s.Name, name);
            var update = Builders<TVModels>.Update.CurrentDate(s => s.UpdateTime);

            UpdateResult actionResult = await _context.TVModels.UpdateOneAsync(filter, update);
            return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }

        public async Task<bool> UpdateTVScreen(string name, TVModels tv)
        {
            ReplaceOneResult actionResult = await _context.TVModels.ReplaceOneAsync(
                s => s.Name == name,
                tv,
                new UpdateOptions { IsUpsert = true }
            );
            return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }

        public async Task<bool> RemoveAllTVScreen()
        {
            DeleteResult actionResult = await _context.TVModels.DeleteManyAsync(new BsonDocument());
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
