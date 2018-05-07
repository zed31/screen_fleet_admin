using screen_fleet_admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace screen_fleet_admin.Repositories
{
    /*! \brief Interface of the resource repository 
     * this interface is used to handle the ResourceModel inside the MongoContext
     * each return value are asynchronous tasks
     */
    public interface IResourceRepository
    {
        /*! @return all the resources coming from the collection of Resources */
        Task<IEnumerable<ResourceModel>> GetAllResources();
        
        /*! @return a specific resource coming from the collection of resources */
        Task<ResourceModel> GetSpecificResource(string id);
        
        /*! \brief Remove a specific resource related to the specific id
         * @param[in]   id  the specific id of the resource
         * @return  true if a resource has been removed properly, false otherwise
         */
        Task<bool> RemoveSpecificResource(string id);

        /*! \brief Update a specific resource related to the specific id
         * @param[in]   id  the id of the resource being updated
         * @param[in]   newResource the new resource being updated
         * @return      true if the resource has been updated, false otherwise
         */
        Task<bool> UpdateResource(string id, ResourceModel newResource);

        /*! \brief Add a new resource to the Resource collection
         * @param[in]   resource    the new resource being added
         * @return      an asynchronous task
         */
        Task AddNewResource(ResourceModel resource);
    }
}
