using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspTravelerApp.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            var faq = new Tuple<string, string>(
                "Why did the chicken cross the road?",
                "To get to the other side"
            );
            return View(faq);
        }
    }
}