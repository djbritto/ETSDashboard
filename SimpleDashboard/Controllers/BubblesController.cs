﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleDashboard.Models;

namespace SimpleDashboard.Controllers
{
    public class BubblesController : Controller
    {
        // GET: Bubbles
        public ActionResult Index()
        {
            return View();
        }

        //Get Fixed Data summary
        public JsonResult GetBubbleJson_all()
        {
            int i = 0;
            using (var ctx = new AdventureEntities())
            {
                var bubble = (from od in ctx.prc_sum_apps_usage_date1()
                              select new
                              {
                                  _date = od.date.Value.ToString("MM/dd/yyyy"),
                                  _ApplicationName = od.applicationname,
                                  _Usage = od.usage.HasValue ? od.usage.Value : 0
                              }).ToList();

                List<bubble> bubble_points = new List<bubble>();

                foreach (var header in bubble)
                {
                    string s_date = header._date;
                    DateTime dateTime = DateTime.ParseExact(s_date, "MM-dd-yyyy", CultureInfo.InvariantCulture);
                    int year = dateTime.Year;
                    int month = dateTime.Month;
                    int day = dateTime.Day;
                    string groups = "";

                    if (header._Usage >= 2)
                    {
                        groups = "high";
                    }
                    else if (header._Usage < 1)
                    {
                        groups = "low";
                    }
                    else
                    {
                        groups = "medium";
                    }
                    bubble_points.Add(new bubble()
                    {
                        id = i++,
                        ApplicationName = header._ApplicationName,
                        Grant_start_date = header._date,
                        group = groups,
                        OrganizationName = header._ApplicationName,
                        Usage = header._Usage,
                        start_day = day,
                        start_month = month,
                        start_year = year
                    });
                }
                //string json = JsonConvert.SerializeObject(bubble_points.ToArray()); 

                return Json(new { bubble_points }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult GetBubbleJson_yearly()
        {
            string format = "01-01-yyyy";
            List<bubble> bubble_points = GetBubbleSummaryByDateFormat(format);
            return Json(new { bubble_points }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBubbleJson_monthly()
        {
            string format = "01-MM-yyyy";
            List<bubble> bubble_points = GetBubbleSummaryByDateFormat(format);
            return Json(new { bubble_points }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetBubbleJson_daily()
        {
            string format = "dd-MM-yyyy";
            List<bubble> bubble_points = GetBubbleSummaryByDateFormat(format);
            return Json(new { bubble_points }, JsonRequestBehavior.AllowGet);
        }

        private static List<bubble> GetBubbleSummaryByDateFormat(string format)
        {
            int i = 0;
            List<bubble> bubble_points = new List<bubble>();
            using (var ctx = new AdventureEntities())
            {
                var bubble = ctx.prc_combined_vol().GroupBy(p => p.date.Value.ToString(format)).
                              Select(g => new
                              {
                                  _date = g.Key,
                                  _fixed = g.Sum(y => y.@fixed),
                                  _mobile = g.Sum(x => x.mobile)
                              }).ToList();
                foreach (var header in bubble)
                {
                    string s_date = header._date;
                    DateTime dateTime = DateTime.ParseExact(s_date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    int year = dateTime.Year;
                    int month = dateTime.Month;
                    int day = dateTime.Day;
                    string groups = "";
                    double Usage = 0;
                    Usage = (double)(header._fixed + header._mobile);

                    if (Usage >= 2)
                    {
                        groups = "high";
                    }
                    else if (Usage < 1)
                    {
                        groups = "low";
                    }
                    else
                    {
                        groups = "medium";
                    }

                    bubble_points.Add(new bubble()
                    {
                        id = i++,
                        Grant_start_date = header._date,
                        group = groups,
                        //Usage = header._Usage.HasValue ? header._Usage.Value : 0,
                        start_day = day,
                        start_month = month,
                        start_year = year,
                        Usage = Usage
                    });
                }
            }

            return bubble_points;
        }

        public JsonResult GetBubbleJson_application()
        {
            int i = 0;
            using (var ctx = new AdventureEntities())
            {
                var bubble = ctx.prc_combined_vol().GroupBy(p => p.applicationname).
                              Select(g => new
                              {
                                  _ApplicationName = g.Key,
                                  _fixed = g.Sum(x => x.@fixed),
                                  _mobile = g.Sum(y => y.mobile)
                              }).ToList();

                List<bubble> bubble_points = new List<bubble>();



                foreach (var header in bubble)
                {
                    string groups = "";
                    if (header._fixed >= 2)
                    {
                        groups = "high";
                    }
                    else if (header._fixed < 1)
                    {
                        groups = "low";
                    }
                    else
                    {
                        groups = "medium";
                    }

                    bubble_points.Add(new bubble()
                    {
                        id = i++,
                        ApplicationName = header._ApplicationName,
                        group = groups,
                        OrganizationName = header._ApplicationName,
                        //Usage = header._Usage.HasValue ? header._Usage.Value : 0
                        Usage = (double)(header._fixed + header._mobile)
                    });
                }
                return Json(new { bubble_points }, JsonRequestBehavior.AllowGet);
            }

        }

        //Get Mobile Data summary
        //public JsonResult m_GetBubbleJson_all()
        //{
        //    int i = 0;
        //    using (var ctx = new AdventureEntities())
        //    {
        //        var bubble = (from od in ctx.prc_mobile_sum_apps_usage()
        //                      select new
        //                      {
        //                          _date = od.date.Value.ToString("MM/dd/yyyy"),
        //                          _ApplicationName = od.applicationname,
        //                          _Usage = od.usage.HasValue ? od.usage.Value : 0
        //                      }).ToList();

        //        List<bubble> bubble_points = new List<bubble>();

        //        foreach (var header in bubble)
        //        {
        //            string s_date = header._date;
        //            DateTime dateTime = DateTime.ParseExact(s_date, "MM-dd-yyyy", CultureInfo.InvariantCulture);
        //            int year = dateTime.Year;
        //            int month = dateTime.Month;
        //            int day = dateTime.Day;
        //            string groups = "";

        //            if (header._Usage >= 2)
        //            {
        //                groups = "high";
        //            }
        //            else if (header._Usage < 1)
        //            {
        //                groups = "low";
        //            }
        //            else
        //            {
        //                groups = "medium";
        //            }
        //            bubble_points.Add(new bubble()
        //            {
        //                id = i++,
        //                ApplicationName = header._ApplicationName,
        //                Grant_start_date = header._date,
        //                group = groups,
        //                OrganizationName = header._ApplicationName,
        //                Usage = header._Usage,
        //                start_day = day,
        //                start_month = month,
        //                start_year = year
        //            });
        //        }
        //        //string json = JsonConvert.SerializeObject(bubble_points.ToArray()); 

        //        return Json(new { bubble_points }, JsonRequestBehavior.AllowGet);
        //    }

        //}
        //public JsonResult m_GetBubbleJson_yearly()
        //{
        //    string format = "01-01-yyyy";
        //    List<bubble> bubble_points = m_GetBubbleSummaryByDateFormat(format);
        //    return Json(new { bubble_points }, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult m_GetBubbleJson_monthly()
        //{
        //    string format = "01-MM-yyyy";
        //    List<bubble> bubble_points = m_GetBubbleSummaryByDateFormat(format);
        //    return Json(new { bubble_points }, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult m_GetBubbleJson_daily()
        //{
        //    string format = "dd-MM-yyyy";
        //    List<bubble> bubble_points = m_GetBubbleSummaryByDateFormat(format);
        //    return Json(new { bubble_points }, JsonRequestBehavior.AllowGet);
        //}
        //private static List<bubble> m_GetBubbleSummaryByDateFormat(string format)
        //{
        //    int i = 0;
        //    List<bubble> bubble_points = new List<bubble>();
        //    using (var ctx = new AdventureEntities())
        //    {
        //        var bubble = ctx.prc_mobile_sum_apps_usage().GroupBy(p => p.date.Value.ToString(format)).
        //                      Select(g => new
        //                      {
        //                          _date = g.Key,
        //                          _Usage = g.Sum(x => x.usage)
        //                      }).ToList();
        //        foreach (var header in bubble)
        //        {
        //            string s_date = header._date;
        //            DateTime dateTime = DateTime.ParseExact(s_date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        //            int year = dateTime.Year;
        //            int month = dateTime.Month;
        //            int day = dateTime.Day;
        //            string groups = "";

        //            if (header._Usage >= 2)
        //            {
        //                groups = "high";
        //            }
        //            else if (header._Usage < 1)
        //            {
        //                groups = "low";
        //            }
        //            else
        //            {
        //                groups = "medium";
        //            }

        //            bubble_points.Add(new bubble()
        //            {
        //                id = i++,
        //                Grant_start_date = header._date,
        //                group = groups,
        //                Usage = header._Usage.HasValue ? header._Usage.Value : 0,
        //                start_day = day,
        //                start_month = month,
        //                start_year = year
        //            });
        //        }
        //    }

        //    return bubble_points;
        //}
        //public JsonResult m_GetBubbleJson_application()
        //{
        //    int i = 0;
        //    using (var ctx = new AdventureEntities())
        //    {
        //        var bubble = ctx.prc_mobile_sum_apps_usage().GroupBy(p => p.applicationname).
        //                      Select(g => new
        //                      {
        //                          _ApplicationName = g.Key,
        //                          _Usage = g.Sum(x => x.usage)
        //                      }).ToList();

        //        List<bubble> bubble_points = new List<bubble>();

        //        foreach (var header in bubble)
        //        {
        //            string groups = "";
        //            if (header._Usage >= 2)
        //            {
        //                groups = "high";
        //            }
        //            else if (header._Usage < 1)
        //            {
        //                groups = "low";
        //            }
        //            else
        //            {
        //                groups = "medium";
        //            }
        //            bubble_points.Add(new bubble()
        //            {
        //                id = i++,
        //                ApplicationName = header._ApplicationName,
        //                group = groups,
        //                OrganizationName = header._ApplicationName,
        //                Usage = header._Usage.HasValue ? header._Usage.Value : 0
        //            });
        //        }
        //        return Json(new { bubble_points }, JsonRequestBehavior.AllowGet);
        //    }

        //}

        //highchart bubbles


        //HighChartBubbles
        
    }
}