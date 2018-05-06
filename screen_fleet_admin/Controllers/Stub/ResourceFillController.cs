using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using screen_fleet_admin.Repositories;
using screen_fleet_admin.Models;

namespace screen_fleet_admin.Controllers.Stub
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ResourceFillController : Controller
    {
        private readonly IResourceRepository _repository;

        public ResourceFillController(IResourceRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public String PostResource()
        {
            _repository.AddNewResource(new ResourceModel()
            {
                Name = "First resource",
                RawId = "1",
                InsertionDate = DateTime.Now,
                UpdateTime = DateTime.Now,
                ResourceType = "none",
                Leaf1 = null,
                Leaf2 = null,
                BinaryData = null
            });
            _repository.AddNewResource(new ResourceModel()
            {
                Name = "Second resource",
                RawId = "2",
                InsertionDate = DateTime.Now,
                UpdateTime = DateTime.Now,
                ResourceType = "tree",
                Leaf1 = new ResourceModel()
                {
                    Name = "Inner resource",
                    RawId = "2.1",
                    InsertionDate = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    ResourceType = "none",
                    Leaf1 = null,
                    Leaf2 = null,
                    BinaryData = null
                },
                Leaf2 = new ResourceModel()
                {
                    Name = "Inner resource",
                    RawId = "2.2",
                    InsertionDate = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    ResourceType = "tree",
                    Leaf1 = new ResourceModel()
                    {
                        Name = "Inner resource",
                        RawId = "2.2.1",
                        InsertionDate = DateTime.Now,
                        UpdateTime = DateTime.Now,
                        ResourceType = "binary",
                        Leaf1 = null,
                        Leaf2 = null,
                        BinaryData = new byte[3] { (byte)'t', (byte)'0', (byte)'p' }
                    },
                    Leaf2 = new ResourceModel()
                    {
                        Name = "Inner resource",
                        RawId = "2.2.1",
                        InsertionDate = DateTime.Now,
                        UpdateTime = DateTime.Now,
                        ResourceType = "binary",
                        Leaf1 = null,
                        Leaf2 = null,
                        BinaryData = new byte[3] { (byte)'b', (byte)'0', (byte)'t' }
                    },
                    BinaryData = null
                }
            });
            _repository.AddNewResource(new BinaryResourceModel()
            {
                Name = "Third resource",
                RawId = "3",
                InsertionDate = DateTime.Now,
                UpdateTime = DateTime.Now,
                ResourceType = "binary",
                BinaryData = new byte[3] { (byte)'b', (byte)'0', (byte)'t' },
                Leaf1 = null,
                Leaf2 = null
            });
            return "Done";
        }
    }
}