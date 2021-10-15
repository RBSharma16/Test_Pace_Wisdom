using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PaceWisdomAssignment.Filters;
using PaceWisdomAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaceWisdomAssignment.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public static string _url = "?jsoncallback=jQuery110201501142482738942_1450853406889&tags=mount+rainier&tagmode=any&format=json&_=1450853406890";
        [Session]
        public ActionResult Index()
        {
            return View();
        }
        [Session]
        public JsonResult GetApiData()
        {
            var data = StaticInstances.GetStringAsync(_url);
            string json = JsonConvert.SerializeObject(data);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [Session]
        public ActionResult Details(string id)
        {
            ViewData["name"] = id;
            return View();
        }
        [Session]
        public ActionResult List()
        {
            DataMain _main = StaticInstances.GetDataAsyncModel<DataMain>(_url);
            TempData["ApiData"] = _main;
            return View(_main);
        }
        [Session]
        public ActionResult ModelDetails(string id)
        {
            DataMain _main = (DataMain)TempData.Peek("ApiData");
            items _item = _main.items.Where(x => x.title == id).FirstOrDefault();
            return View(_item);
        }
    }
}