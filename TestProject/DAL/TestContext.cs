using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TestProject.DAL
{
    public class TestContext : DbContext
    {
        public TestContext() : base("MyContext") { }

        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Apartment> Apartments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<TestProject.Models.HouseView> HouseViews { get; set; }
    }
}