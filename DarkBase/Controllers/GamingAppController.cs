using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DarkBase.Models;


namespace DarkBase.Controllers
{
    public class GamingAppController : Controller
    {
        // GET: GamingApp
        [HttpGet]
        public ActionResult Index()
        {
            using (var ctx = new AdventureEntities())
            {
                var cmbdata = ctx.ets_eprobe_avg_server().Select(x => x.GameName).Distinct().ToList();

                ViewBag.cmbdata = cmbdata.Select(r => new SelectListItem { Text = r, Value = r });
            }
            return View();
        }
        public JsonResult GetLineGameData(string GName, string hours)
        {
            using (var ctx = new AdventureEntities())
            {
                DateTime hours_in = Convert.ToDateTime(hours);

                var GetLine = (from od in ctx.ets_eprobe_avg_server()
                               select new GameDetails
                               {
                                   GameName = od.GameName,
                                   ServerLocation = od.ServerLocation,
                                   RTT = od.Avg_RTT.Value,
                                   UsuageDateStr = od.datatime_hour.ToString("dd-MMM-yyyy HH:mm"),
                                   UsageDate = od.datatime_hour
                               }).Where(x => x.GameName == GName && x.UsageDate >= hours_in)
                               .ToList();

                var ServerNames = ctx.ets_eprobe_avg_server().Where(y => y.GameName == GName && y.datatime_hour >= hours_in).Select(x => x.ServerLocation).Distinct().ToList();
                                  

                List<GameDetails> gameDetails = new List<GameDetails>();

                foreach (var lines in GetLine)
                {

                    gameDetails.Add(new GameDetails() { GameName = lines.GameName, RTT = lines.RTT, ServerLocation = lines.ServerLocation, UsuageDateStr = lines.UsuageDateStr });

                }

                List<DistinctServer> distinctServers = new List<DistinctServer>();
                foreach (var item in ServerNames)
                {
                    distinctServers.Add(new DistinctServer() { ServerLocation=item});
                }

                GameMaster gameProbeData = new GameMaster();
                gameProbeData.GameDetails = gameDetails;
                gameProbeData.GameServer = distinctServers;

                return Json(new { gameProbeData }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}