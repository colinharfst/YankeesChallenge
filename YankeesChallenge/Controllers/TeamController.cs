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
    public class TeamController : ControllerBase
    {
        private static readonly List<Team> Teams = new List<Team>
        {
            new Team { Name = "New York Yankees", Abbreviation = "NYY", PlayerIds = null, Players = null },
            new Team { Name = "Boston Red Sox", Abbreviation = "BOS", PlayerIds = null, Players = null },
            new Team { Name = "Baltimore Orioles", Abbreviation = "BAL", PlayerIds = null, Players = null },
        };

        private readonly ILogger<TeamController> _logger;

        public TeamController(ILogger<TeamController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{abbreviation}")]
        public IActionResult Get(string abbreviation)
        {
            Team t = Teams.FirstOrDefault(t => t.Abbreviation == abbreviation);
            return t is null ? NotFound() : Ok(t);
        }
    }
}
