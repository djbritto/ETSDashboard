using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DarkBase.Models;

namespace DarkBase.Controllers
{
    public class EProbeController : Controller
    {
        // GET: EProbe
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetProbeData(DateTime fromdate,DateTime todate)
        {
            using (var ctx = new AdventureEntities())
            {
                var gamelines = (from od in ctx.prc_eprobe_avg()
                               select new
                               ProbeDetail
                               {
                                   UsageDate = od.datatime_hour,
                                   GameName = od.GameName,
                                   RTT = od.RTT.Value,
                                   UsuageDateStr = od.datatime_hour.ToString("dd-MMM-yyyy HH:mm:00")
                               })
                               .Where(x => (x.UsageDate >= fromdate && x.UsageDate <= todate))
                               .ToList();


                List<GameEProbeData> gameProbeDatas = gamelines.GroupBy(g => g.GameName)
                                                                        .Select(g => new GameEProbeData
                                                                        {
                                                                            GameName = g.Key,
                                                                            ProbeDetail = g.OrderBy(x => x.UsageDate).ToList()                                                                   
                                                                        }).ToList();

                return Json(new { gameProbeDatas = gameProbeDatas }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}