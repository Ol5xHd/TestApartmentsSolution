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
    public class CitiesController : Controller
    {
        private readonly TestContext db = new TestContext();

        // GET: All cities
        public ActionResult Index()
        {
            List<CityView> cities = new List<CityView>();

            List<City> cities_raw = db.Cities.Select(c => c).ToList();
            foreach(City c in cities_raw)
            {
                cities.Add(new CityView { 
                    CityId = c.ID,
                    CityName = c.Name,
                    StreetsCount = c.Streets.Count
                });
            }
            
            return View(cities);
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
