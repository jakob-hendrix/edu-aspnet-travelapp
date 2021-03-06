﻿using AspTravelerApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspTravelerApp.Controllers
{
    public class TripController : BaseController
    {
        private TripDbContext db = new TripDbContext();

        public TripController(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        public IActionResult Index() => View();
        

        public IActionResult Test()
        {

            var trips = new Models.Trip[]
            {
                new Models.Trip { Name = "Vacation 1" },
                new Models.Trip { ID = 13 }
            };
            return Json(trips);
        }

        public IActionResult Search() => View();
    }
}