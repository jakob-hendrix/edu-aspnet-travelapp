using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspTravelerApp.Controllers
{
    public class TripController : BaseController
    {
        public TripController(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            var trips = new Models.Trip[]
            {
                new Models.Trip { Name = "Vacation 1" },
                new Models.Trip { ID = 13 }
            };
            return Json(trips);
        }
    }
}