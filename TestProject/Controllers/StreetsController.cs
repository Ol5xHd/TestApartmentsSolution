using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestProject.DAL;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class StreetsController : Controller
    {
        private readonly TestContext db = new TestContext();

        // GET: All streets
        public ActionResult Index()
        {
            var streets = db.Streets.Include(s => s.City);
            return View(streets.ToList());
        }

        // GET: Streets by city id
        public ActionResult GetByCity(int id)
        {
            City city = db.Cities.First(c => c.ID == id);
            ViewData["CityName"] = city.Name;

            List<StreetView> streets = new List<StreetView>();

            List<Street> streets_raw = db.Streets.Where(s => s.CityID == city.ID).ToList();
            foreach(Street s in streets_raw)
            {
                streets.Add(new StreetView {
                    StreetId = s.ID,
                    StreetName = s.Name,
                    HousesCount = s.Houses.Count
                });
            }

            return View(streets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
