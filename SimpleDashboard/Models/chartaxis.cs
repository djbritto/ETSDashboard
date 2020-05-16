using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleDashboard.Models
{
    public class chartaxis
    {
        public List<string> x { get; set; }
        public List<prc_sum_fixed_Result> y { get; set; }

        public chartdots chartdots { get; set; }
        public drilldown drilldown { get; set; }
        public List<DrillDownHeader> drillDownHeader { get; set; }
        public List<DrillDownDetails> drillDownDetail { get; set; }

    }


    public class DrillDownHeader
    {
        public string ApplicationName { get; set; }
        public double TotalUsage { get; set; }
    }

    public class DrillDownDetails
    {
        public string ApplicationName { get; set; }
        public DateTime drillDownDate { get; set; }
        public string CreateDateString { get; set; }
        public double Usage { get; set; }
    }
}