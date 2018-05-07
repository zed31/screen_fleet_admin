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
        [HttpGet]
        public async Task<IEnumerable<ResourceModel>> GetResources()
        {
            return await _repository.GetAllResources();
        }
    }
}