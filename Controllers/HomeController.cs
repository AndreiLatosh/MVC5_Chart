using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication3.Models;
using System.Web.UI;
using System.Data.Entity;
using System;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        private ChartContext db = new ChartContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 30)]
        [HttpPost]
        public ActionResult InputData(UserData ud)
        {           

            if (ud.RangeFrom >= ud.RangeTo)
            {
                ModelState.AddModelError("", "RangeFrom > RangeTo");
            }

            if ((ud.RangeTo - ud.RangeFrom) > 10000)
            {
                ModelState.AddModelError("", "Too much points");
            }

            if (ModelState.IsValid)
            {
                var check = db.UserDatas.FirstOrDefault(d => d.A == ud.A && d.B == ud.B && d.C == ud.C && d.RangeFrom == ud.RangeFrom && d.RangeTo == ud.RangeTo && d.Step == ud.Step);

                if (check != null)
                {                  
                    var existsPoints = db.Points.Where(p => p.UserDataId == check.Id).ToList();
                    return Json(existsPoints, JsonRequestBehavior.AllowGet);
                }

                List<Point> points = new List<Point>();

                for (int i = ud.RangeFrom; i <= ud.RangeTo; i += ud.Step)
                {
                    Point p = new Point();
                    p.X = i;
                    p.Y = ud.A * i * i + ud.B * i + ud.C;
                    points.Add(p);
                    db.Points.Add(p);
                }

                db.UserDatas.Add(ud);

                db.SaveChanges();

                return Json(points, JsonRequestBehavior.AllowGet);
            }

            ViewBag.Message = "Запрос не прошел валидацию на сервере";
            return PartialView(ud);
        }       
    }

}
