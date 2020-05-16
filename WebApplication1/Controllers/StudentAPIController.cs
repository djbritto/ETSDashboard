using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class StudentAPIController : Controller
    {
        // GET: api/GetAllStudents  
        [HttpGet]
    
        public ActionResult GetProbeData()
        {
            using (var ctx = new AdventureEntities())
            {
                var GetProbeData = ctx.prc_ets_probe_data().ToList();
                return Json(new { GetProbeData }, JsonRequestBehavior.AllowGet);
            }
            
        }

    }
}