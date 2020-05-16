using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkBase.Models
{
    public class GameProbeData
    {
        public string GameName { get; set; }
        public double RTT { get; set; }
        
        public string UsuageDateStr { get; set; }
        public DateTime TimeRange { get; set; }
        public List<GameDetails> GameDetails { get; set; }
    }



    public class GameDetails
    {
        public string GameName { get; set; }
        public double RTT { get; set; }
        public string UsuageDateStr { get; set; }
        public DateTime UsageDate { get; set; }

        public string ServerLocation { get; set; }
    }
    public class GameMaster
    {
        public List<GameDetails> GameDetails { get; set; }
        public List<GameProbeData> GameProbeData { get; set; }
        public List<DistinctServer> GameServer { get; set; }
    }

    public class DistinctServer
    {
        public string ServerLocation { get; set; }
    }

}