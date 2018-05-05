using MongoDB.Bson;

namespace screen_fleet_admin.Repositories
{
    public static class RepositoryUtils
    {
        public static ObjectId GetInternalId(string name)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(name, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }
    }
}
