using DarkBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DarkBase.Controllers
{
    public class TrendsController : Controller
    {
        // GET: Trends
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetDataMaster()
        {
            using (var ctx = new AdventureEntities())
            {

                var datausage = (from od in ctx.prc_data_summary().OrderByDescending(x => x.date)
                                     select new
                                     {
                                         date = od.date.Value.ToString("MMM/dd"),
                                         m_usage = od.Mobile_Data__TB_.HasValue ? od.Mobile_Data__TB_.Value : 0,
                                         f_usage = od.Fixed_Data__PB_.HasValue ? od.Fixed_Data__PB_.Value : 0
                                     }).Take(20).ToList();

                return Json(new { datausage }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult GetVoiceMaster()
        {
            using (var ctx = new AdventureEntities())
            {

                var voicedata = (from od in ctx.prc_voice_summary().OrderByDescending(x => x.date)
                                       select new
                                       {
                                           date = od.date.Value.ToString("MMM/dd"),
                                           m_voice = od.Mobile_Voice__erlang_.HasValue ? od.Mobile_Voice__erlang_.Value : 0,
                                           f_voice = od.Fixed_Voice__mins_.HasValue ? od.Fixed_Voice__mins_.Value : 0,
                                           idd_voice = od.IDD_OG__mins_.HasValue ? od.IDD_OG__mins_.Value : 0
                                       }).Take(20).ToList();

                return Json(new { voicedata }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult GetIsupMaster()
        {
            using (var ctx = new AdventureEntities())
            {

                var sup_combinedtable = (from od in ctx.prc_isup_summary().OrderByDescending(x => x.date)
                                         select new
                                         {
                                             date = od.date.Value.ToString("MMM/dd"),
                                             asr = od.ISUP_ASR__perc_.HasValue ? od.ISUP_ASR__perc_.Value : 0,
                                             nernw = od.ISUP_NER_NW__perc_.HasValue ? od.ISUP_NER_NW__perc_.Value : 0,
                                             sipasr = od.ISUP_SIP_ASR__perc_.HasValue ? od.ISUP_SIP_ASR__perc_.Value : 0,
                                             sipnernw = od.ISUP_SIP_NER_NW__perc_.HasValue ? od.ISUP_SIP_NER_NW__perc_.Value : 0
                                         }).Take(7).ToList();

                return Json(new { sup_combinedtable }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetTopAppsMaster()
        {
            using (var ctx = new AdventureEntities())
            {

                var top_combinedtable = (from od in ctx.prc_top_apps_summary()
                                         select new
                                         {
                                             date = od.date.Value.ToString("MMM/dd"),
                                             t_mob = od.Mobile_Top_Apps_Volume__TB_.HasValue ? od.Mobile_Top_Apps_Volume__TB_.Value : 0,
                                             t_fix = od.Fixed_Top_Apps_Volume__PB_.HasValue ? od.Fixed_Top_Apps_Volume__PB_.Value : 0,
                                             c_iptv = od.IPTV_users_count.HasValue ? od.IPTV_users_count.Value : 0
                                         }).Take(10).ToList();

                return Json(new { top_combinedtable }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult Get_Iptv_Count()
        {
            using (var ctx = new AdventureEntities())
            {
                var get_iptv_count = (from od in ctx.prc_iptv_count()
                                      select new
                                      {
                                          count = od.IPTV_Users_Count.HasValue ? od.IPTV_Users_Count : 0,
                                          daily = od.date.Value.Date,
                                          monthly = new DateTime(od.date.Value.Year, od.date.Value.Month, 1, 0, 0, 0),
                                          hourly = new DateTime(od.date.Value.Year, od.date.Value.Month, od.date.Value.Day, int.Parse(od.Hour.Value.ToString()), 0, 0)
                                      }).ToList();

                var get_daily = get_iptv_count.GroupBy(x => x.daily).Select(g => new { name = g.Key, count = Math.Round(g.Average(x => x.count).Value) }).ToList();
                var get_monthly = get_iptv_count.GroupBy(x => x.monthly).Select(g => new { name = g.Key, count = Math.Round(g.Average(x =>x.count).Value) }).ToList();
                var get_hourly = get_iptv_count.OrderByDescending(x => x.daily).GroupBy(x => x.hourly).Select(g => new { name = g.Key, count = g.Average(x => Math.Round(x.count.Value)) }).Take(24).ToList();

                List<IPTV_User_Count> iPTV_User_Counts_d = new List<IPTV_User_Count>();
                foreach (var item in get_daily)
                {
                    iPTV_User_Counts_d.Add(new IPTV_User_Count() { Day = item.name.ToString("MMM-dd"), Daily_Count = item.count.ToString() });
                }

                List<IPTV_User_Count> iPTV_User_Counts_m = new List<IPTV_User_Count>();
                foreach (var item in get_monthly)
                {
                    iPTV_User_Counts_m.Add(new IPTV_User_Count() { Month = item.name.ToString("MMM-yyyy"), Monthly_Count = item.count.ToString() });
                }

                List<IPTV_User_Count> iPTV_User_Counts_h = new List<IPTV_User_Count>();
                foreach (var item in get_hourly)
                {
                    iPTV_User_Counts_h.Add(new IPTV_User_Count() { Hour = item.name.ToString("HH:mm"), Hourly_Count = item.count.ToString() });
                }

                var data = new
                {
                    Daily = iPTV_User_Counts_d,
                    Monthly = iPTV_User_Counts_m,
                    Hourly = iPTV_User_Counts_h
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
    }

}