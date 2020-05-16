using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather
        public ActionResult Index()
        {
            return View();
        }
        string Baseurl = "https://www.metaweather.com/";
        [HttpGet]
        [Route("api/AjaxAPI/AjaxMethod")]
       //  public async Task<ActionResult> GetWeather()
       public async Task<ActionResult> ShowData()

           //  public JsonResult ShowData()
        {
            List<Weather> WeatherInfo = new List<Weather>();


            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await  client.GetAsync("api/location/search/?query=san");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var WeatherResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    WeatherInfo = JsonConvert.DeserializeObject<List<Weather>>(WeatherResponse);

                }
                //returning the employee list to view  
                //return View(WeatherInfo);
                return Json(WeatherInfo, JsonRequestBehavior.AllowGet);
            }
        }
    }
}


