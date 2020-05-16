using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleDashboard.Models;

namespace SimpleDashboard.Controllers
{
    public class OverAllController : Controller
    {
        // GET: OverAll
        public ActionResult Index()
        {
            using (var ctx = new AdventureEntities())
            {
                var get_peeks_fixed = ctx.prc_sum_apps_usage_date1().GroupBy(p => p.date)
                                            .Select(g => new { date = g.Key.Value.ToString("MM/dd/yyyy"), count = g.Sum(x => x.usage) })
                                            .OrderByDescending(x => x.count).FirstOrDefault();

                var get_peeks_count = ctx.prc_get_peek_count().Select(g=> new {date= g.date.Value.ToString("MM/dd/yyyy"), hour=g.Hour.Value,iptv=g.IPTV_Users_Count.Value })
                                        .OrderByDescending(x => x.date)
                                            .FirstOrDefault();

               

                ViewBag.get_peek_count= get_peeks_count.ToExpando();
                

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
        public ActionResult GetActiviyDaily()
        {
            using (var ctx = new AdventureEntities())
            {
                var get_activity = ctx.prc_combined_vol().GroupBy(p => p.date.Value.ToString("MM/dd/yyyy")).
                              Select(g => new
                              {
                                  date = g.Key,
                                  f_usage = Math.Round((g.Sum(y => y.@fixed.Value)), 0),
                                  m_usage = Math.Round((g.Sum(x => x.mobile.Value)), 0)
                              }).OrderByDescending(x => x.date).FirstOrDefault();

                

                return Json(new { get_activity }, JsonRequestBehavior.AllowGet);
            }
        }

    }


}

