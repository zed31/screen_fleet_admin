using MongoDB.Bson;
using MongoDB.Driver;
using screen_fleet_admin.Contexts;
using screen_fleet_admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace screen_fleet_admin.Repositories
{
    /*! \brief Class that handle the repository of the TV */
    public class TVRepository : ITVRepository
    {
        private readonly MongoContext<TVModel> _context = null;
        private readonly static string COLLECTION_NAME = "TVModel";

        /*! \brief Constructor of the TVRepository class
         * @param[in]   context The mongo db context of the TVModel
         */
        public TVRepository(MongoContext<TVModel> context)
        {
            _context = context;
        }

        /*! \brief Get all the tv data from the Mongo context
         * @return an async task containing a collection of TVModel
         */
        public async Task<IEnumerable<TVModel>> GetAllTVScreens()
        {
            return await _context.Collection(COLLECTION_NAME).Find(_ => true).ToListAsync();
        }

        /*! \brief Get a specific tv screen according to its raw id
         * @param[in]   rawId    the raw id of the tv screen
         * @return an async task containing the tv model
         */
        public async Task<TVModel> GetTVScreen(string rawId)
        {
            ObjectId internalId = RepositoryUtils.GetInternalId(rawId);
            return await _context
                .Collection(COLLECTION_NAME)
                .Find(tv => tv.RawId == rawId)
                .FirstOrDefaultAsync();
        }

        /*! \brief Add tv Model to the database
         * @param[in]   model   the model to be inserted
         */
        public async Task AddTVScreen(TVModel model)
        {
            await _context.Collection(COLLECTION_NAME).InsertOneAsync(model);
        }

        /*! \brief Remove a specific tv with the specific RawId
         * @param[in]   rawId   The raw id of the tv screen
         * @return      an asynchronous task wrapping a boolean, true if the deletion happened successfully, false otherwise
         */
        public async Task<bool> RemoveTVScreen(string rawId)
        {
            DeleteResult deleteAction = await _context
                .Collection(COLLECTION_NAME)
                .DeleteOneAsync(Builders<TVModel>.Filter.Eq("RawId", rawId));
            return deleteAction.IsAcknowledged && deleteAction.DeletedCount > 0;
        }

        /*! \brief Update the specific tv screen that maps the specific raw id
         * @param[in]   rawId   The RawId of the specific model
         * @param[in]   tv      The TV model
         * @return  an asynchronous task wrapping a boolean, return true if the modification has successfully done, false
         *          otherwise
         */
        public async Task<bool> UpdateTVScreen(string rawId, TVModel tv)
        {
            ReplaceOneResult actionResult = await _context.Collection(COLLECTION_NAME).ReplaceOneAsync(
                s => s.RawId == rawId,
                tv,
                new UpdateOptions { IsUpsert = true }
            );
            return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }

        /*! \brief Modify the content of a TV screen by updating every resources in it
         * @param[in]   rawId   the raw id of the TV screen
         * @param[in]   tv      the model binding of the TV
         * @return      an asynchronous task set to true if the modification has been taken into account, false otherwise
         */
        public async Task<bool> UpdateTVScreenContent(string rawId, TVModel tv)
        {
            var filter = Builders<TVModel>.Filter.Eq("RawId", rawId);
            var update = Builders<TVModel>.Update
                .Set(s => s.Name, tv.Name)
                .Set(s => s.Resource, tv.Resource)
                .Set(s => s.Ip, tv.Ip)
                .Set(s => s.InsertionDate, tv.InsertionDate)
                .Set(s => s.UpdateTime, tv.UpdateTime);

            UpdateResult actionResult = await _context.Collection(COLLECTION_NAME).UpdateOneAsync(filter, update);
            return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        }

        /*! \brief Remove all the tv screens
         * @return  an asynchronous task wrapping a boolean, return true if the deletion has been successfully done, false
         *          otherwise
         */
        public async Task<bool> RemoveAllTVScreen()
        {
            DeleteResult actionResult = await _context.Collection(COLLECTION_NAME).DeleteManyAsync(new BsonDocument());
            return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        }
    }
}
