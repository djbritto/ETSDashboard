using DarkBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkBase.Controllers
{
    public class dashboardController : Controller
    {
        // GET: dashboard
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult GetSparkData()
        {
            using (var ctx = new AdventureEntities())
            {

                var f_header = ctx.prc_sum_apps_usage_date1().Select(x => x.applicationname).Distinct();

                var f_lines = (from od in ctx.prc_combined_vol()
                               select new
                               UsuageDetail
                               {
                                   UsuageDate = od.date.Value,
                                   ApplicationName = od.applicationname,
                                   Mobile_Usage = od.mobile.HasValue ? od.mobile.Value : 0,
                                   Fixed_Usage = od.@fixed.HasValue ? od.@fixed.Value : 0,
                                   UsuageDateStr = od.date.Value.ToString("dd-MMM-yyyy")
                               }).ToList();

                  
                
                List<ApplicationDailyComparisionData> applicationData = f_lines.GroupBy(g => g.ApplicationName)
                                                                        .Select(g => new ApplicationDailyComparisionData { ApplicationName = g.Key, UsuageDetails = g.OrderBy(x => x.UsuageDate)
                                                                        .ToList() }).ToList();


                foreach (var header in applicationData)
                {
                    //header.UsuageDetails =  header.UsuageDetails.OrderByDescending(i => i.UsuageDate).Take(10).ToList();
                    var currentData = header.UsuageDetails.OrderByDescending(i => i.UsuageDate).FirstOrDefault();
                    var previousData = header.UsuageDetails.OrderByDescending(i => i.UsuageDate).Skip(1).Take(1).SingleOrDefault();
                    var fixed_avgData = header.UsuageDetails.Select(x => x.Fixed_Usage).Average();
                    var mobile_avgData = header.UsuageDetails.Select(x => x.Mobile_Usage).Average();

                    header.FixedPreviousDate= previousData.UsuageDate;
                    header.MobilePreviousDate = previousData.UsuageDate;

                    header.FixedPreviousUsage = previousData.Fixed_Usage;
                    header.MobilePreviousUsage = previousData.Mobile_Usage;
                    
                    header.FixedCurrentDate = currentData.UsuageDate;
                    header.MobileCurrentDate = currentData.UsuageDate;

                    header.FixedCurrentUsage = currentData.Fixed_Usage;
                    header.MobileCurrentUsage = currentData.Mobile_Usage;
                    
                    header.Fixed_Avg_Usage = Math.Round(fixed_avgData, 3);
                    header.Mobile_Avg_Usage = Math.Round(mobile_avgData, 3);

                    //header.UsuageDifference = Math.Round(header.PreviousUsage - header.CurrentUsage, 2);
                    header.Fixed_UsuageDifference = Math.Round((header.FixedPreviousUsage - header.FixedCurrentUsage),3);
                    header.Mobile_UsuageDifference = Math.Round((header.MobilePreviousUsage - header.MobileCurrentUsage),3);
                    header.IsFixed_Up = header.Fixed_UsuageDifference > 0;
                    header.IsMobile_Up = header.Mobile_UsuageDifference > 0;
                }

                return Json(new { applicationData = applicationData }, JsonRequestBehavior.AllowGet);
            }
        }
        
        //Partial View
        public ActionResult SideMenu()
        {
            return PartialView("_SideMenu");

        }
    }
}