using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleDashboard.Models
{
    public class chartdots
    {
        public IList<Series> series { get; set; }
    }
    public class Datum
    {
        public string x { get; set; }
        public double y { get; set; }
        public string drilldown { get; set; }
    }

    public class Series
    {
        public string name { get; set; }
        public bool colorByPoint { get; set; }
        public IList<Datum> data { get; set; }
    }

   
}