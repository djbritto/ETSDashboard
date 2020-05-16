using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleDashboard.Models
{
    public class sunburstpoints
    {        
        //public List<prc_sum_apps_usage_date1_Result> y { get; set; }
        public List<SbHeader> s_burn_Header { get; set; }
        public List<SbDetail> s_burn_Detail { get; set; }
        public List<sb_ring_header> s_sbring_hd { get; internal set; }
    }

    public class sb_ring_header
    {
        public string U_Id { get; set; }
}
    public class SbHeader
    {
        public string ApplicationName { get; set; }

        
        public string sburnDate { get; set; }
    }

    public class SbDetail
    {
        public string d_ApplicationName { get; set; }
        public string sburnDate { get; set; }
        public double TotalUsage { get; set; }
    }
}