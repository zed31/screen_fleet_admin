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
        [HttpGet("list")]
        public async Task<IEnumerable<TVModel>> Get()
        {
            return await _tvRepository.GetAllTVScreens();
        }

        /*! \brief Get a specific TV thanks to the rawId of the tv
         * @param[in]   rawId   The RawID of the specific tv
         * @return  an asynchronous task containing the TVModel related to the rawId
         */
        [HttpGet("list/{rawId}")]
        public async Task<TVModel> Get(string rawId)
        {
            return await _tvRepository.GetTVScreen(rawId);
        }

        /*! \brief Put request used to update a specific tv related to the rawId
         * @param[in]   rawId   The RawId of the TV screen
         * @param[in]   tvModel The TVModel retrieved from the request body
         */
        [HttpPatch("modify")]
        public async Task<bool> UpdateTv([FromBody] TVModel tvModel)
        {
            return await _tvRepository.UpdateTVScreenContent(tvModel.RawId, tvModel);
        }

        /*! \brief Add a TV screen to the database
         * @param[in]   tvModel The model of a simple TV
         * @return      an asynchronous task
         */
        [HttpPost("insert")]
        public async Task CreateTv([FromBody] TVModel tvModel)
        {
            await _tvRepository.AddTVScreen(new TVModel()
            {
                RawId = tvModel.RawId,
                Ip = tvModel.Ip,
                Name = tvModel.Name,
                Resource = tvModel.Resource,
                InsertionDate = tvModel.InsertionDate,
                UpdateTime = tvModel.UpdateTime
            });
        }

        /*! \brief Remove a tv screen related to the specific RawId
         * @param[in]   rawId   The raw id of the tv
         * @return      an asynchronous task that is set to true if the deletion succeed, false otherwise
         */
        [HttpDelete("remove/{RawId}")]
        public async Task<bool> DeleteTV(string rawId)
        {
            return await _tvRepository.RemoveTVScreen(rawId);
        }
    }
}