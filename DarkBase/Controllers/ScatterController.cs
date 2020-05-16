using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DarkBase.Models;

namespace DarkBase.Controllers
{
    public class ScatterController : Controller
    {
        // GET: Scatter
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetProbeScatter()
        {
            using (var ctx = new AdventureEntities())
            {
                var ScatterData = (from od in ctx.ets_eprobe_avg_server()
                                 select new
                                 {
                                     UsageDate       = od.datatime_hour,
                                     GameName        = od.GameName,
                                     Server          = od.ServerLocation,
                                     RTT             = od.Avg_RTT.Value,
                                     UsuageDateStr   = od.datatime_hour.ToString("dd-MMM-yyyy HH:mm:00")
                                 })
                               .ToList();
                 

                return Json(new { ScatterData }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}