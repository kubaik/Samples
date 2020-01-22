using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Actor.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class ActorsController : ControllerBase
    {
        private static readonly string[] Actors = new[]
        {
            "Tom Holland", "Robert Downey Jr", "Benedict Cumberbatch"
        };

        private readonly ILogger<ActorsController> _logger;

        public ActorsController(ILogger<ActorsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get() => Actors;
    }
}