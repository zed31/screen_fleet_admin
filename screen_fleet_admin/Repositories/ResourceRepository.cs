using MongoDB.Bson;
using MongoDB.Driver;
using screen_fleet_admin.Contexts;
using screen_fleet_admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace screen_fleet_admin.Repositories
{
    /*! \brief Class that handle the context of the ResourceModel in mongo db */
    public class ResourceRepository : IResourceRepository
    {
        private readonly MongoContext<ResourceModel> _context = null;
        private readonly static string COLLECTION_NAME = "ResourceModel";

        /*! \brief Constructor of the Resource repository
         * @param[in]   context the mongodb context of the resource model
         */
        public ResourceRepository(MongoContext<ResourceModel> context)
        {
            _context = context;
        }

        /*! \brief Get all the resources from the ResourceModel collection
         * @return an asynchronous task containing a collection of resource model
         */
        public async Task<IEnumerable<ResourceModel>> GetAllResources()
        {
            return await _context.Collection(COLLECTION_NAME).Find(_ => true).ToListAsync();
        }

        /*! \brief Get a specific resource related to the id
         * @param[in]   id  the RawId of the resource
         * @return      an asynchronous task containing a ResourceModel object
         */
        public async Task<ResourceModel> GetSpecificResource(string id)
        {
            return await _context.Collection(COLLECTION_NAME).Find(
                resource => resource.RawId == id
            ).FirstOrDefaultAsync();
        }

        /*! \brief Remove a specific resource related to the RawID id
         * @param[in]   id  the RawID of the resource
         * @return      an asynchronous task containing a boolean that returns true if the deletion has been successfully
         *              done, false otherwise
         */
        public async Task<bool> RemoveSpecificResource(string id)
        {
            DeleteResult actionResult = await _context.Collection(COLLECTION_NAME).DeleteOneAsync(
                Builders<ResourceModel>.Filter.Eq("RawId", id)
            );
            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }

        /*! \brief Update the specific resource related to a specific RawId
         * @param[in]   id  the RawId of the specific resource
         * @param[in]   newResource The updated resource
         */
        public async Task<bool> UpdateResource(string id, ResourceModel newResource)
        {
            var filter = Builders<ResourceModel>.Filter.Eq("RawId", id);
            var update = Builders<ResourceModel>.Update
                .Set(s => s.Name, newResource.Name)
                .Set(s => s.Leaf1, newResource.Leaf1)
                .Set(s => s.Leaf2, newResource.Leaf2)
                .Set(s => s.InsertionDate, newResource.InsertionDate)
                .Set(s => s.ResourceType, newResource.ResourceType)
                .Set(s => s.Path, newResource.Path)
                .Set(s => s.UpdateTime, newResource.UpdateTime);

            UpdateResult actionResult = await _context.Collection(COLLECTION_NAME).UpdateOneAsync(filter, update);
            return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }

        /*! \brief Add a new resource to the resource collection
         * @param[in]   resource    the resource added to the collection
         */
        public async Task AddNewResource(ResourceModel resource)
        {
            await _context.Collection(COLLECTION_NAME).InsertOneAsync(resource);
        }
    }
}
