using Microsoft.AspNetCore.Mvc;
using screen_fleet_admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace screen_fleet_admin.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TVController : Controller
    {
        private readonly IRepository _tvRepository = null;

        public TVController(IRepository tvRepository)
        {
            _tvRepository = tvRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TVModels>> Get()
        {
            return await _tvRepository.GetAllTVScreens();
        }

        [HttpGet("{name}")]
        public async Task<TVModels> Get(string name)
        {
            return await _tvRepository.GetTVScreen(name);
        }
    }
}