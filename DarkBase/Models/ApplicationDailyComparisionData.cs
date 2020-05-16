using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkBase.Models
{
    public class ApplicationDailyComparisionData
    {
        public string ApplicationName { get; set; }

        public List<UsuageDetail> UsuageDetails { get; set; }
        public decimal Fixed_UsuageDifference { get; set; }
        public decimal Mobile_UsuageDifference { get; set; }
        public decimal FixedPreviousUsage { get; set; }
        public decimal MobilePreviousUsage { get; set; }
        public decimal FixedCurrentUsage { get; set; }
        public decimal MobileCurrentUsage { get; set; }
        public DateTime FixedPreviousDate { get; set; }
        public DateTime MobilePreviousDate { get; set; }
        public DateTime FixedCurrentDate { get; set; }
        public DateTime MobileCurrentDate { get; set; }
        public bool IsFixed_Up { get; set; }
        public bool IsMobile_Up { get; set; }
        public decimal Fixed_Avg_Usage { get; set; }
        public decimal Mobile_Avg_Usage { get; set; }
    }


    public class UsuageDetail
    {
        public string ApplicationName { get; set; }
        public double Usage { get; set; }

        public decimal Mobile_Usage { get; set; }
        public decimal Fixed_Usage { get; set; }
        public DateTime UsuageDate { get; set; }
        public string UsuageDateStr { get; set; }
    }
}