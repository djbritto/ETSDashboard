using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleDashboard.Models;

namespace SimpleDashboard.Controllers
{
    public class H_BubblesController : Controller
    {
        // GET: H_Bubbles
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetHighBub_Mob()
        {
            using (var ctx = new AdventureEntities())
            {
                var bubble_h = ctx.prc_combined_vol().GroupBy(p => p.applicationname).
                              Select(g => new
                              {
                                  _ApplicationName = g.Key,
                                  _fixed = g.Sum(x => x.@fixed),
                                  _mobile = g.Sum(y => y.mobile)
                              }).ToList();
                return Json(new { bubble_h }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}

