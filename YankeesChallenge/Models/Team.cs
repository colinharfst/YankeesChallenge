using System;
using System.Collections.Generic;

namespace YankeesChallenge
{
    public class Team
    {
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public List<int> PlayerIds { get; set; }

        public List<Player> Players { get; set; }

        // public string teamid { get; set; }
        // public string name { get; set; }
        // public string abbr { get; set; }
        // public string leagueid { get; set; }
        // public string city { get; set; }
    }
}
