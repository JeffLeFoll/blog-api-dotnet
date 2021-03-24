using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly ILogger<BlogPostController> _logger;

        public PingController(ILogger<BlogPostController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> GetPing() => "I'm alive !!";
    }
}
