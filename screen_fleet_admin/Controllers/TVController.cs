using Microsoft.AspNetCore.Mvc;
using screen_fleet_admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using screen_fleet_admin.Repositories;

namespace screen_fleet_admin.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TVController : Controller
    {
        private readonly ITVRepository _tvRepository = null;

        public TVController(ITVRepository tvRepository)
        {
            _tvRepository = tvRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TVModel>> Get()
        {
            return await _tvRepository.GetAllTVScreens();
        }

        [HttpGet("{name}")]
        public async Task<DbModelBase> Get(string name)
        {
            return await _tvRepository.GetTVScreen(name);
        }
    }
}