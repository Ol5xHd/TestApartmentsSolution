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
    public class HousesController : Controller
    {
        private readonly TestContext db = new TestContext();

        // GET: All houses
        public ActionResult Index()
        {
            var houses = db.Houses.Include(h => h.Street);
            return View(houses.ToList());
        }

        // GET: Houses by street id
        public ActionResult GetByStreet(int id)
        {
            Street street = db.Streets.First(s => s.ID == id);
            City city = db.Cities.First(c => c.ID == street.CityID);
            ViewData["CityId"] = city.ID;
            ViewData["CityName"] = city.Name;
            ViewData["StreetName"] = street.Name;

            List<HouseView> houses = new List<HouseView>();

            var houses_raw = db.Houses.Where(h => h.StreetID == street.ID).ToList();
            foreach(House h in houses_raw)
            {
                houses.Add(new HouseView {
                    HouseId = h.ID,
                    HouseNumber = h.Number,
                    ApartmentsCount = h.Apartments.Count,
                    CommonArea = h.Apartments.Sum(a => a.Area)
                });
            }

            return View(houses);
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
