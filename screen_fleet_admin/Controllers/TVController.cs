using Microsoft.AspNetCore.Mvc;
using screen_fleet_admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using screen_fleet_admin.Repositories;

namespace screen_fleet_admin.Controllers
{
    /*! \brief Controller used to control the flow of the api/tv endpoint
     */
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TVController : Controller
    {
        private readonly ITVRepository _tvRepository = null;

        /*! \brief Constructor of the TVController class
         * @param[in]   tvRepository the TV repository injected thanks to the DI startup
         */
        public TVController(ITVRepository tvRepository)
        {
            _tvRepository = tvRepository;
        }

        /*! \brief Get all the tv available on the database
         * @return an asynchronous task containing a collection of TVModel
         */
        [HttpGet]
        public async Task<IEnumerable<TVModel>> Get()
        {
            return await _tvRepository.GetAllTVScreens();
        }

        /*! \brief Get a specific TV thanks to the rawId of the tv
         * @param[in]   rawId   The RawID of the specific tv
         * @return  an asynchronous task containing the TVModel related to the rawId
         */
        [HttpGet("{name}")]
        public async Task<TVModel> Get(string rawId)
        {
            return await _tvRepository.GetTVScreen(rawId);
        }
    }
}