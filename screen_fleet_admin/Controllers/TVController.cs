using Microsoft.AspNetCore.Mvc;
using screen_fleet_admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using screen_fleet_admin.Repositories;
using System.IO;
using System.Text;

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
        [HttpGet("{rawId}")]
        public async Task<TVModel> Get(string rawId)
        {
            return await _tvRepository.GetTVScreen(rawId);
        }

        /*! \brief Put request used to update a specific tv related to the rawId
         * @param[in]   rawId   The RawId of the TV screen
         * @param[in]   tvModel The TVModel retrieved from the request body
         */
        [HttpPut("{rawId}")]
        public async Task<bool> UpdateTv(string rawId, TVModel tvModel)
        {
            using (StreamWriter sw = new StreamWriter("log.txt", true))
            {
                sw.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(tvModel));
            }
            return await _tvRepository.UpdateTVScreen(rawId, tvModel);
        }
    }
}