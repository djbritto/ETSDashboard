using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebApplication1.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetOrders()
        {
            using (var ctx = new AdventureEntities())
            {
                var query = ctx.Orders.Include("Customer")
                             .GroupBy(p => p.Customer.FirstName)
                             .Select(g => new { name = g.Key, count = g.Sum(x => x.TotalAmount) }).ToList();


                return Json(query, JsonRequestBehavior.AllowGet);
            }


        }
        public ActionResult GetOrders1()
        {
            using (var ctx = new AdventureEntities())
            {
                var query1 = ctx.Orders.Include("Customer")
                             .GroupBy(p => p.Customer.FirstName)
                             .Select(g => new { name = g.Key, count = g.Sum(x => x.TotalAmount) }).ToList();


                return Json(query1, JsonRequestBehavior.AllowGet);
            }


        }
        public JsonResult GetDataGrid()
        {
            using (var ctx = new AdventureEntities())
            {
                //var griddata = (from od in ctx.Orders
                //                join cus in ctx.Customers on od.CustomerId equals cus.Id
                //                where cus.Id==85
                //                orderby od.TotalAmount
                //                select new
                //                {
                //                    cus.FirstName,
                //                    od.OrderNumber,
                //                    od.TotalAmount
                //                }).ToList();
                var griddata = ctx.order_master.Where(a=>a.FirstName=="Paul").OrderBy(a => a.TotalAmount).ToList();

                return Json(new { griddata = griddata  } , JsonRequestBehavior.AllowGet);


            }


        }
        public JsonResult GetDataGrid2()
        {
            using (var ctx = new AdventureEntities())
            {
                //var griddata = (from od in ctx.Orders
                //                join cus in ctx.Customers on od.CustomerId equals cus.Id
                //                where cus.Id==85
                //                orderby od.TotalAmount
                //                select new
                //                {
                //                    cus.FirstName,
                //                    od.OrderNumber,
                //                    od.TotalAmount
                //                }).ToList();
                var griddata2 = ctx.order_master.Where(a => a.FirstName == "Paul").OrderBy(a => a.TotalAmount).ToList();

                return Json(new { griddata = griddata2 }, JsonRequestBehavior.AllowGet);


            }


        }


    }
    }