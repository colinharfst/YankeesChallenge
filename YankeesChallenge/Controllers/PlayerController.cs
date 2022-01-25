using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YankeesChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private static readonly List<Player> Players = new List<Player>
        {
            new Player { Name = "Aaron Judge", Id = 1234, Position = "RF", Homeruns = 55 },
            new Player { Name = "Brett Gardner", Id = 1235, Position = "CF", Homeruns = 25 },
            new Player { Name = "Joey Gallo", Id = 1236, Position = "LF", Homeruns = 45 },
        };

        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            Player p = Players.FirstOrDefault(p => p.Id == id);
            return p is null ? NotFound() : Ok(p);
        }
    }
}
