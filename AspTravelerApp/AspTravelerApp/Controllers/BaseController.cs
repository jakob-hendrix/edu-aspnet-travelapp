using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AspTravelerApp.Controllers
{
    public abstract class BaseController : Controller
    {
        private Stopwatch _timer;
        public BaseController(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger("Controller");
        }
        protected ILogger Logger { get; private set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _timer = Stopwatch.StartNew();
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Elapsed-Time", new[] { _timer.ElapsedMilliseconds.ToString() });

            Logger.LogInformation($"{context.HttpContext.Request.Path} - {_timer.ElapsedMilliseconds}ms");

            base.OnActionExecuted(context);
        }
    }
}