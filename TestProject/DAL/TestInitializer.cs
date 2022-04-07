using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject.Models;

namespace TestProject.DAL
{
    public class TestInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TestContext>
    {
        protected override void Seed(TestContext context)
        {
            var cities = new List<City>
            {
                new City{ ID = 1, Name = "Лондон" },
                new City{ ID = 2, Name = "Минас-Тирит" },
                new City{ ID = 3, Name = "Караганда" }
            };
            cities.ForEach(c => context.Cities.Add(c));
            context.SaveChanges();

            var streets = new List<Street>
            {
                new Street{ ID = 1, Name = "Лепсовская", CityID = 1 },
                new Street{ ID = 2, Name = "Букингемская", CityID = 1 },
                new Street{ ID = 3, Name = "Дождливая", CityID = 1 },

                new Street{ ID = 4, Name = "Большая Гондорская", CityID = 2 },
                new Street{ ID = 5, Name = "Кольцевая", CityID = 2 },
                new Street{ ID = 6, Name = "Белая", CityID = 2 },

                new Street{ ID = 7, Name = "Гдегде", CityID = 3 },
                new Street{ ID = 8, Name = "Орталык", CityID = 3 },
                new Street{ ID = 9, Name = "Казактар", CityID = 3 },
            };
            streets.ForEach(s => context.Streets.Add(s));
            context.SaveChanges();

            for(int id = 1; id < 3 * 3 * 3 + 1; ++id)
            {
                // 1, 1, 1
                // 2, 1, 2
                // 3, 1, 3
                // 4, 2, 4
                // ..
                // 9, 3, 9
                // 10, 4, 1
                // 11, 4, 2
                // ...
                // 27, 9, 9
                context.Houses.Add(new House{ ID = id, StreetID = (id + 2) / 3, Number = id - 9 * ((id - 1) / 9) });
            }
            context.SaveChanges();

            var rand = new Random();
            for(int id = 1; id < 3 * 3 * 3 * 3 * 3 + 1; ++id)
            {
                context.Apartments.Add(new Apartment{ ID = id, HouseID = (id + 8) / 9, Area = rand.NextDouble() * 100 });
            }
            context.SaveChanges();
        }
    }
}