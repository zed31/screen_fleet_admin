using MongoDB.Bson;

namespace screen_fleet_admin.Repositories
{
    /*! \brief Repository utilities used inside repository classes */
    public static class RepositoryUtils
    {
        /*! \brief Check if the given id is an ObjectId
         * @param[in]   id  the id being checked
         * @return      an empty object id if the id is not a correct id
         */
        public static ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }
    }
}
