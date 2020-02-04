using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Movie.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class MoviesController : ControllerBase
    {
        private static readonly string[] Actors = new[]
        {
            "Spider Man", "Irom Man", "Doctor Strange"
        };

        private readonly ILogger<MoviesController> _logger;

        public MoviesController(ILogger<MoviesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get() => Actors;
    }
}