using Microsoft.AspNetCore.Mvc;
using screen_fleet_admin.Models;
using screen_fleet_admin.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace screen_fleet_admin.Controllers
{
    /*! \brief Class used to handle the resource control
     */
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ResourceController : Controller
    {
        private readonly IResourceRepository _repository;

        /*! \brief Constructor of the ResourceController
         * @param[in]   repository the repository of the resource
         */
        public ResourceController(IResourceRepository repository)
        {
            _repository = repository;
        }

        /*! \brief Get all the resources registered inside the composition
         * @return  An asynchronous task containing an enumerable container of resource model
         */
        [HttpGet("list")]
        public async Task<IEnumerable<ResourceModel>> GetResources()
        {
            return await _repository.GetAllResources();
        }

        /*! \brief Get a specific resource related to the `RawId`
         * @param[in]   RawId   The RawId field of the specific resource
         * @return      an asynchronous task containing a ResourceModel object, or Nothing if no object
         *              is found
         */
        [HttpGet("list/{RawId}")]
        public async Task<ResourceModel> GetSpecificResource(string RawId)
        {
            return await _repository.GetSpecificResource(RawId);
        }

        /*! \brief Add Specific resource into the Resource Collection
         * @param[in]   resource    The resource retrieved from the body of the post request
         * @return      an asynchronous task containing only an Http code
         */
        [HttpPost("insert")]
        public async Task Insert([FromBody] ResourceModel resource)
        {
            await _repository.AddNewResource(RepositoryUtils.GenerateNewModel(resource));
        }

        /*! \brief Edit a specific resource from the MongoDB database
         * @param[in]   resource    the new content of the resource retrieved from the request body
         * @return      an asynchronous task set to true if the edit succeed, false otherwise
         */
        [HttpPut("modify")]
        public async Task<bool> Edit([FromBody] ResourceModel resource)
        {
            return await _repository.UpdateResource(resource.RawId, RepositoryUtils.GenerateNewModel(resource));
        }

        /*! \brief Remove a specific resource containing the `RawId`
         * @param[in]   rawId   The id of the resource
         * @return      an asynchronous task that returns true if the deletion succeed, false otherwise
         */
        [HttpDelete("remove/{RawId}")]
        public async Task<bool> Remove(string rawId)
        {
            return await _repository.RemoveSpecificResource(rawId);
        }
    }
}