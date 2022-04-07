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
    public class ApartmentsController : Controller
    {
        private readonly TestContext db = new TestContext();

        // GET: All apartments
        public ActionResult Index()
        {
            var apartments = db.Apartments.Include(a => a.House);
            return View(apartments.ToList());
        }

        // GET: Apartments by house id
        public ActionResult GetByHouse(int id, double? areaFrom, double? areaUpTo)
        {
            House house = db.Houses.First(h => h.ID == id);
            Street street = db.Streets.First(s => s.ID == house.StreetID);
            City city = db.Cities.First(c => c.ID == street.CityID);
            ViewData["CityName"] = city.Name;
            ViewData["StreetName"] = street.Name;
            ViewData["StreetId"] = street.ID;
            ViewData["HouseId"] = house.ID;
            ViewData["HouseNumber"] = house.Number;
            ViewData["AreaFrom"] = areaFrom;
            ViewData["AreaUpTo"] = areaUpTo;

            List<ApartmentView> apartments = new List<ApartmentView>();

            List<Apartment> apartments_raw = db.Apartments
                .Where(a => a.HouseID == house.ID)
                .Where(a => !areaFrom.HasValue || a.Area >= areaFrom)
                .Where(a => !areaUpTo.HasValue || a.Area <= areaUpTo)
                .ToList();
            foreach(Apartment a in apartments_raw)
            {
                apartments.Add(new ApartmentView { 
                    ApartmentId = a.ID,
                    ApartmentArea = a.Area
                });
            }
            
            return View(apartments);
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
