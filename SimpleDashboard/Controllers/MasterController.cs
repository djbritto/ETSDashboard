using SimpleDashboard.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleDashboard.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult Index()
        {
            using (var ctx = new AdventureEntities())
            {
                var get_peeks_fixed = ctx.prc_sum_apps_usage_date1().GroupBy(p => p.date)
                                            .Select(g => new { date = g.Key.Value.ToString("MM/dd/yyyy"), count = g.Sum(x => x.usage) })
                                            .OrderByDescending(x => x.count).FirstOrDefault();
                
                ViewBag.getpeeks = get_peeks_fixed.ToExpando(); 
            }
            return View();
        }
        public ActionResult GetDataMaster()
        {
            using (var ctx = new AdventureEntities())
            {

                var combinedtable = (from od in ctx.prc_comb_master()
                                     select new
                                     {
                                         date = od.date.Value.ToString("MM/dd/yyyy"),
                                         m_usage = od.mobile.HasValue ? od.mobile.Value : 0,
                                         f_usage = od.@fixed.HasValue ? od.@fixed.Value : 0
                                     }).ToList();




                return Json(new { combinedtable }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult GetDataCombine_mobile()
        {
            using (var ctx = new AdventureEntities())
            {
                var get_pie_master_mobile = (from od in ctx.prc_top5_mobile()
                                             select new
                                             {
                                                 apps = od.applicationname,
                                                 usage = od.usage.HasValue ? od.usage.Value : 0
                                             }).Take(5).ToList();

                return Json(new { get_pie_master_mobile }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetDataCombine_fixed()
        {
            using (var ctx = new AdventureEntities())
            {
                var get_pie_master_fixed = (from od in ctx.prc_top5_fixed()
                                            select new
                                            {
                                                apps = od.applicationname,
                                                usage = od.usage.HasValue ? od.usage.Value : 0
                                            }).Take(5).ToList();

                var get_peeks_fixed = ctx.prc_sum_apps_usage_date1().GroupBy(p => p.date)
                                            .Select(g => new { date = g.Key, count = g.Sum(x => x.usage) })
                                            .OrderByDescending(x => x.count).FirstOrDefault();

                //ViewBag.peeks = get_peeks_fixed;

                return Json(new { get_pie_master_fixed }, JsonRequestBehavior.AllowGet);
            }
        }
        //public ActionResult Get_Peeks_fixed()
        //{
        //    using (var ctx = new AdventureEntities())
        //    {
        //        var get_peeks_fixed = ctx.prc_sum_apps_usage_date1().GroupBy(p => p.date)
        //                                    .Select(g => new { date = g.Key, count = g.Sum(x => x.usage) })
        //                                    .OrderByDescending(x => x.count).FirstOrDefault();

        //        //var get_peeks_fixed1= ctx.prc_sum_apps_usage_date1()
        //        //group y by x.CARS into g
        //        //select new { CARID = g.Key, agg1 = g.Max(z => z.WINDOWS), agg2 = g.Max(z => z.YEAR) }


        //        ViewBag.peeks = get_peeks_fixed;

        //        return Json(new { get_peeks_fixed }, JsonRequestBehavior.AllowGet);
        //    }
        //}


    }


    public static class Extensions
    {
        public static ExpandoObject ToExpando(this object anonymousObject)
        {
            IDictionary<string, object> anonymousDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(anonymousObject);
            IDictionary<string, object> expando = new ExpandoObject();
            foreach (var item in anonymousDictionary)
                expando.Add(item);
            return (ExpandoObject)expando;
        }
    }
}

