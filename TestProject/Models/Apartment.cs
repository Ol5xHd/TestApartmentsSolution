using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Apartment
    {
        [Key]
        public int ID { get; set; }
        public int HouseID { get; set; }
        public double Area { get; set; }

        public virtual House House { get; set; }
    }
}