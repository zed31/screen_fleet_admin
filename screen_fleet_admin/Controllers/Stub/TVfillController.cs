﻿using Microsoft.AspNetCore.Mvc;
using screen_fleet_admin.Models;
using screen_fleet_admin.Repositories;
using System;

namespace screen_fleet_admin.Controllers
{
    // Used only for developpment not for production, this scenario is ugly
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TVfillController : Controller
    {
        private readonly ITVRepository _tvRepository = null;

        public TVfillController(ITVRepository tvRepository)
        {
            _tvRepository = tvRepository;
        }

        [HttpPost]
        public string PostTv()
        {
            _tvRepository.AddTVScreen(new TVModel()
            {
                Name = "First tv",
                Ip = "192.168.1.1",
                InsertionDate = DateTime.Now,
                UpdateTime = DateTime.Now
            });
            _tvRepository.AddTVScreen(new TVModel()
            {
                Name = "Second tv",
                Ip = "192.168.1.2",
                InsertionDate = DateTime.Now,
                UpdateTime = DateTime.Now
            });
            _tvRepository.AddTVScreen(new TVModel()
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