using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleDashboard.Models;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Globalization;


namespace SimpleDashboard.Controllers
{
    public class DashboardsController : Controller
    {
        
        // GET: Dashboards
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDataGrid()
        {
            using (var ctx = new AdventureEntities())
            {
                

                var date = (from fd in ctx.fixed_top_ups
                            orderby fd.Date
                            select new
                            {
                                fd.Date.Value
                            }).ToList();
                List<string> lstDate = new List<string>();
                foreach (var item in date)
                {
                    lstDate.Add(item.Value.ToString());
                }

                var columnnames = (from t in typeof(fixed_top_ups).GetProperties() select t.Name).ToList();

                var x_column = ctx.prc_sum_apps_usage().ToList();

                var x_header = ctx.prc_sum_fixed().ToList();

                var x_detail = ctx.prc_sum_apps_usage_date1().ToList();
                

                List<DrillDownHeader> drillDownHeaders = new List<DrillDownHeader>();
                 
                foreach (var header in x_column)
                {
                    drillDownHeaders.Add(new DrillDownHeader() { ApplicationName = header.applicationname , TotalUsage=header.usage.Value });

                }

                List<DrillDownDetails>  drillDownDetails = new List<DrillDownDetails>();
                foreach (var det in x_detail)
                {
                    drillDownDetails.Add(new DrillDownDetails() { ApplicationName = det.applicationname, drillDownDate = det.date.Value, Usage = det.usage.Value, CreateDateString = det.date.Value.ToString("MM/dd/yyyy") });
                }
                 
                chartaxis chartaxis = new chartaxis();               
                chartaxis.drillDownHeader = drillDownHeaders;
                chartaxis.drillDownDetail = drillDownDetails;

                return Json(new { chartaxis }, JsonRequestBehavior.AllowGet);

                // return Json(griddata, JsonRequestBehavior.AllowGet);

            }

        }

        public ActionResult SideMenu()
        {
            return PartialView("_SideMenu");

        }
        public ActionResult HSideMenu()
        {
            return PartialView("_SideMenu");

        }
    }
}