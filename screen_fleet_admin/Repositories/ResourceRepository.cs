using MongoDB.Bson;
using MongoDB.Driver;
using screen_fleet_admin.Contexts;
using screen_fleet_admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace screen_fleet_admin.Repositories
{
    public class ResourceRepository
    {
        private readonly MongoContext<ResourceModel> _context = null;

        public ResourceRepository(MongoContext<ResourceModel> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResourceModel>> GetAllResources()
        {
            return await _context.Collection.Find(_ => true).ToListAsync();
        }

        public async Task<ResourceModel> GetSpeicifcResource(string id)
        {
            ObjectId internalId = RepositoryUtils.GetInternalId(id);
            return await _context.Collection.Find(
                resource => resource.RawId == id || resource.Id == internalId
            ).FirstOrDefaultAsync();
        }
    }
}
