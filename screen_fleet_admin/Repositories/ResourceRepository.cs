using MongoDB.Bson;
using MongoDB.Driver;
using screen_fleet_admin.Contexts;
using screen_fleet_admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace screen_fleet_admin.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly MongoContext<ResourceModel> _context = null;
        private readonly static string COLLECTION_NAME = "RepositoryModel";

        public ResourceRepository(MongoContext<ResourceModel> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResourceModel>> GetAllResources()
        {
            return await _context.Collection(COLLECTION_NAME).Find(_ => true).ToListAsync();
        }

        public async Task<ResourceModel> GetSpecificResource(string id)
        {
            ObjectId internalId = RepositoryUtils.GetInternalId(id);
            return await _context.Collection(COLLECTION_NAME).Find(
                resource => resource.RawId == id || resource.Id == internalId
            ).FirstOrDefaultAsync();
        }

        public async Task<bool> RemoveSpecificResource(string id)
        {
            DeleteResult actionResult = await _context.Collection(COLLECTION_NAME).DeleteOneAsync(
                Builders<ResourceModel>.Filter.Eq("RawId", id)
            );
            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }

        public async Task<bool> UpdateResource(string id, ResourceModel newResource)
        {
            ReplaceOneResult actionResult = await _context.Collection(COLLECTION_NAME).ReplaceOneAsync(
                s => s.RawId == id,
                newResource,
                new UpdateOptions { IsUpsert = true }
            );
            return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }

        public async Task AddNewResource(ResourceModel resource)
        {
            await _context.Collection(COLLECTION_NAME).InsertOneAsync(resource);
        }
    }
}
