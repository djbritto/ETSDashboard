﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleDashboard.Models
{
   
    public class bubble
    {
        public string ApplicationName { get; set; }
        public int id { get; set; }
        public string OrganizationName { get; set; }
       public double Usage { get; set; }

        public double fixed_data { get; set; }
        public double mobile_data { get; set; }

        public string group { get; set; }
        public string Grant_start_date { get; set; }
        public int start_month { get; set; }
        public int start_day { get; set; }
        public int start_year { get; set; }

        public string type { get; set; } 
    }


}