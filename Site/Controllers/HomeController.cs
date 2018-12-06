using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Site.Models;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        LastContext db = new LastContext();

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Following()
        {
            ViewBag.Type = new SelectList(new List<string>() { "Сухой", "Наливной", "Живой","животного происхождения" });
            ViewBag.From = new SelectList(new List<string>() { "Одесса", "Днепр", "Чернигов", "Харьков", "Житомир",
                "Полтава", "Херсон", "Киев", "Запорожье", "Луганск", "Донецк", "Винница", "АР Крым",
                "Кировоград", "Николаев", "Сумы", "Львов", "Черкассы", "Хмельницкий", "Луцк", "Ровно",
                "Ивано-Франковск", "Тепнополь", "Ужгород", "Черновцы", "Севастополь" });
            

            SelectList Driv = new SelectList(db.Drivers, "Id", "FullName");
            return View("Following2");
        }

        [HttpPost]
        public ActionResult DriverInfo(Order order)
        {
            ViewBag.Order = order;
            var result = db.Drivers.Where(m => m.CarRef.Weight >= order.Mass).ToList();
            return PartialView(result);
        }
        
        [HttpPost]
        public ActionResult AcceptOrder(Order jsonobj)
        {
            var FullName = db.Drivers.FirstOrDefault(m => m.Id == jsonobj.DriverId);
            db.Orders.Add(jsonobj);
            db.SaveChanges();
            return Json(new { jsonobj.Type, jsonobj.Mass, jsonobj.From, jsonobj.To, jsonobj.Date, FIO = FullName });

        }


        public FileResult Download()
        {
            
             return File("~/Documents/HelloWorld.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }


        public ActionResult Tariphs()
        {
            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}