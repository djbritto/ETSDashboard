using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkBase.Models
{
    public class GameEProbeData
    {
        public string GameName { get; set; }
        public double RTT { get; set; }
        
        public string UsuageDateStr { get; set; }
        public DateTime TimeRange { get; set; }
        public List<ProbeDetail> ProbeDetail { get; set; }
    }
     

    public class ProbeDetail
    {
        public string GameName { get; set; }
        public double RTT { get; set; }
        public string UsuageDateStr { get; set; }
        public DateTime UsageDate { get; set; }

        public string ServerLocation { get; set; }
    }
   

}