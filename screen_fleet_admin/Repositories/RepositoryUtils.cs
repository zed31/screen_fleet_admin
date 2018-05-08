using MongoDB.Bson;
using screen_fleet_admin.Models;

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

        /*! \brief Generate new model according to the specific given model
         * It removes only the ObjectID mongoDB to generate a new one
         * @param[in]   model   the model deeply copied
         * @return      A deep copy of the `model` parameter
         */
        public static ResourceModel GenerateNewModel(ResourceModel model)
        {
            return new ResourceModel()
            {
                Name = model.Name,
                ResourceType = model.ResourceType,
                RawId = model.RawId,
                Leaf1 = model.Leaf1,
                Leaf2 = model.Leaf2,
                Path = model.Path,
                InsertionDate = model.InsertionDate,
                UpdateTime = model.UpdateTime
            };
        }

        /*! \brief Generate new TVModel by copying the `model` parameter. It removes the ObjectId
         * coming from MongoDB for convenience
         * @param[in]   model   the model deeply copied
         * @return      A new deep copy of the `model` parameter
         */
        public static TVModel GenerateNewModel(TVModel model)
        {
            return new TVModel()
            {
                Name = model.Name,
                RawId = model.RawId,
                Ip = model.Ip,
                InsertionDate = model.InsertionDate,
                UpdateTime = model.UpdateTime,
                Resource = model.Resource
            };
        }
    }
}
