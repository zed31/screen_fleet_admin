using Microsoft.AspNetCore.Mvc;
using screen_fleet_admin.Models;
using screen_fleet_admin.Repositories;
using System;

namespace screen_fleet_admin.Controllers
{
    /*! \brief Class used to control the route api/tvfill to fill the TVModel collection 
     */
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TVfillController : Controller
    {
        private readonly ITVRepository _tvRepository = null;

        /*! \brief Constructor of the TVFill controller
         * @param[in]   tvRepository    
         */
        public TVfillController(ITVRepository tvRepository)
        {
            _tvRepository = tvRepository;
        }

        /*! \brief Send dummy data into the TVModel mongo db collection
         * @return a string to identify when the request is done
         */
        [HttpPost]
        public string PostTv()
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
                    Path = null
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

            _tvRepository.AddTVScreen(new TVModel()
            {
                Name = "First tv",
                Ip = "192.168.1.1",
                InsertionDate = DateTime.Now,
                UpdateTime = DateTime.Now,
                Resource = r1
            });
            _tvRepository.AddTVScreen(new TVModel()
            {
                Name = "Second tv",
                Ip = "192.168.1.2",
                InsertionDate = DateTime.Now,
                UpdateTime = DateTime.Now,
                Resource = r2
            });
            _tvRepository.AddTVScreen(new TVModel()
            {
                Name = "Third tv",
                Ip = "192.168.1.3",
                InsertionDate = DateTime.Now,
                UpdateTime = DateTime.Now,
                Resource = r3
            });
            return "Done";
        }

        /*! \brief Delete all the tv thanks to the tv repository
         * @return a string with \"Done\" tag
         */
        [HttpDelete]
        public string DeleteAll()
        {
            _tvRepository.RemoveAllTVScreen();
            return "Done";
        }
    }
}