using Microsoft.AspNetCore.Mvc;
using screen_fleet_admin.Models;
using screen_fleet_admin.Repositories;
using System;

namespace screen_fleet_admin.Controllers
{
    /*! \brief Controller of the Resource fill, fill the Resource collection */
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ResourceFillController : Controller
    {
        private readonly IResourceRepository _repository = null;

        /*! \brief Constructor of the Resource fill controller setup the good repository thanks
         * to the dependency injection
         * @param[in]   repository the resource repository
         */
        public ResourceFillController(IResourceRepository repository)
        {
            _repository = repository;
        }

        /*! \brief Feed the Resource collection
         * @return a string containing \"Done\" when it's finish
         */
        [HttpPost]
        public string FillResourceTable()
        {
            ResourceModel r1 = new ResourceModel()
            {
                Name = "First resource",
                RawId = "1",
                InsertionDate = DateTime.Now,
                UpdateTime = DateTime.Now,
                ResourceType = "none",
                Leaf1 = null,
                Leaf2 = null,
                Path = null
            };

            ResourceModel r2 = new ResourceModel()
            {
                Name = "Second resource",
                RawId = "2",
                InsertionDate = DateTime.Now,
                UpdateTime = DateTime.Now,
                ResourceType = "tree-horizontal",
                Leaf1 = new ResourceModel()
                {
                    Name = "Inner resource",
                    RawId = "2.1",
                    InsertionDate = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    ResourceType = "none",
                    Leaf1 = null,
                    Leaf2 = null,
                    Path = null
                },
                Leaf2 = new ResourceModel()
                {
                    Name = "Inner resource",
                    RawId = "2.2",
                    InsertionDate = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    ResourceType = "tree-vertical",
                    Leaf1 = new ResourceModel()
                    {
                        Name = "Inner resource",
                        RawId = "2.2.1",
                        InsertionDate = DateTime.Now,
                        UpdateTime = DateTime.Now,
                        ResourceType = "binary",
                        Leaf1 = null,
                        Leaf2 = null,
                        Path = "http://google.com"
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
                        Path = "http://google.com"
                    },
                    Path = null
                }
            };

            ResourceModel r3 = new ResourceModel()
            {
                Name = "Third resource",
                RawId = "3",
                InsertionDate = DateTime.Now,
                UpdateTime = DateTime.Now,
                ResourceType = "binary",
                Path = "http://google.com",
                Leaf1 = null,
                Leaf2 = null
            };

            _repository.AddNewResource(r1);
            _repository.AddNewResource(r2);
            _repository.AddNewResource(r3);
            return "Done";
        }
    }
}