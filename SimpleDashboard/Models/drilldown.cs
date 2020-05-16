using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleDashboard.Models
{
    public class drilldown
    {
        public IList<Series> series { get; set; }
    }

    public class DSeries
    {
        public string name { get; set; }
        public string id { get; set; }
        public IList<IList<object>> data { get; set; }
    }

  

}