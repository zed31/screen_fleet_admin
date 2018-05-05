using Microsoft.AspNetCore.Mvc;
using screen_fleet_admin.Models;
using System;

namespace screen_fleet_admin.Controllers
{
    // Used only for developpment not for production, this scenario is ugly
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SystemController : Controller
    {
        private readonly IRepository _tvRepository = null;

        public SystemController(IRepository tvRepository)
        {
            _tvRepository = tvRepository;
        }

        [HttpPost]
        public string Post()
        {
            _tvRepository.AddTVScreen(new TVModels()
            {
                Name = "First tv",
                Ip = "192.168.1.1",
                InsertionDate = DateTime.Now,
                UpdateTime = DateTime.Now
            });
            _tvRepository.AddTVScreen(new TVModels()
            {
                Name = "Second tv",
                Ip = "192.168.1.2",
                InsertionDate = DateTime.Now,
                UpdateTime = DateTime.Now
            });
            _tvRepository.AddTVScreen(new TVModels()
            {
                Name = "Third tv",
                Ip = "192.168.1.3",
                InsertionDate = DateTime.Now,
                UpdateTime = DateTime.Now
            });
            return "Done";
        }
    }
}