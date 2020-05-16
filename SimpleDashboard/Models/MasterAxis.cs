using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleDashboard.Models
{
    public class MasterAxis
    {
        public List<string> x { get; set; }

        public double m_usage { get; set; }

        public double f_usage { get; set; }

        public DateTime xdate { get; set; }
        public string CreateDateString { get; set; }
    }
}