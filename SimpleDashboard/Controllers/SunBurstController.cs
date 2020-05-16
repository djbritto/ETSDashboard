using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleDashboard.Models;

namespace SimpleDashboard.Controllers
{
    public class SunBurstController : Controller
    {
        // GET: SunBurst
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSunBurst()
        {
            using (var ctx = new AdventureEntities())
            {
                var sunburst = (from od in ctx.prc_sum_apps_usage_date1()
                                select new
                                {
                                    date = od.date.Value.ToString("MM/dd/yyyy"),
                                    apps = od.applicationname,
                                    usage = od.usage.HasValue ? od.usage : 0
                                }).ToList();



                var appnames = ctx.prc_sum_apps_usage_date1().Select(p => p.applicationname).Distinct();


                List<sb_ring_header> _sbring_hd = new List<sb_ring_header>();
                List<SbHeader> _sbHeaders = new List<SbHeader>();
                foreach (var header in appnames)
                {

                    _sbring_hd.Add(new sb_ring_header() { U_Id = header });
                    foreach (var dtl in sunburst.Where(i=>i.apps==header))
                    {
                        _sbHeaders.Add(new SbHeader { sburnDate = dtl.date, ApplicationName = dtl.apps });
                    }
                }

                                                                      
                List<SbDetail> _sbDetail = new List<SbDetail>();
                foreach (var detail in sunburst)
                {
                    _sbDetail.Add(new SbDetail() { TotalUsage = detail.usage.Value, sburnDate = detail.date, d_ApplicationName=detail.apps });
                }

                sunburstpoints sbpoints = new sunburstpoints();
                sbpoints.s_burn_Header = _sbHeaders;
                sbpoints.s_burn_Detail = _sbDetail;
                sbpoints.s_sbring_hd = _sbring_hd;


                return Json(new { sbpoints }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}