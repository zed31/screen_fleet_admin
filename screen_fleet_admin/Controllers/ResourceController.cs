using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using screen_fleet_admin.Repositories;
using screen_fleet_admin.Models;
using Newtonsoft.Json;

namespace screen_fleet_admin.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ResourceController : Controller
    {
        private readonly IResourceRepository _repository;

        public ResourceController(IResourceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ResourceModel>> GetResources()
        {
            return await _repository.GetAllResources();
        }
    }
}